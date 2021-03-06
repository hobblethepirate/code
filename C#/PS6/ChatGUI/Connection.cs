﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;

//written by James Shaver, October 2011 for Cs 3500 PS6

namespace ChatGUI
{
    /// <summary>
    /// Connection Class - represents the Model as part of the MVC structure. Connection class provides users
    /// a way to create connections and have it connect successfully. The connection class handles all server 
    /// communication from given ChatServer project and reorganizes it into simple typed strings. The connection
    /// object allows users to create a seperate thread for a connection while sending messages to whatever is 
    /// listening to it. Connection Class handles all socket/connection code.
    /// </summary>
    class Connection
    {
        private TcpClient client;
        private IPAddress ipAddress = IPAddress.Parse("127.0.0.1");
        private Thread serverMessage;
        private NetworkStream stream;
        private string serverOut = "";
        private Boolean formClose = false;
        private int port = 4000;
        private string name = "Anonymous";   
        private List<string> sessions = new List<string>();
        private int type = 0;
        private string temp;
        private string output="";
        public Boolean state;
        public delegate void InfoEventHandler(String msg, int input);
        public event InfoEventHandler message;



        /// <summary>
        /// Connection Constructor - creates a connection object and starts it's event state 
        /// in false (no messages available)
        /// </summary>
        public Connection()
        {
            state = false;
        }

        /// <summary>
        /// SendRecipMessage- takes the given message and sends msg and type of message through
        /// an event to any other program register to listen to it.
        /// <param name="msg"> Message to be sent to the listener</param>
        /// </summary>
        private void SendRecipMessage(String msg)
         {
             if (message != null)
             {
                 message(msg,type);
             }
         }

        /// <summary>
        /// DiditChange - method used to make sure the sent message is something that is a new 
        /// event or that the state has changed to true for.
        /// </summary>
        public void DidItChange()
         {
             if (state == true)
             {
                 SendRecipMessage(output);
             }
             state = false;
         }

        /// <summary>
        /// Connected is ment to return the state of the current tcpclient connection.
        /// 
        /// <returns>A Boolean value that is true if connected and false if not connected</returns>
        /// </summary>
        public Boolean Connected()
        {
            return client.Connected;
        }

        /// <summary>
        /// Start Connection Thread starts the connection to given server, it takes a user given input
        /// for a string parses it as an ipaddress and port. The method also starts the ServerMessage thread if
        /// a connection is succeeded. Whether the connection succeeded or not the server then returns 
        /// a Boolean value for the connection state.
        /// 
        /// <returns>A Boolean value that is true if connected and false if not connected</returns>
        /// <param name="input"> User defined string that is a combination of the ip and port</param>
        /// </summary>
        public Boolean StartConnectionThread(string input)
        {
            client = new TcpClient();
            if (input.Contains(":") == false)
            {
                return false;
            }
            int a = input.IndexOf(":");
            ipAddress = IPAddress.Parse(input.Substring(0, a));
            port = Convert.ToInt32(input.Substring(a + 1));
            IPEndPoint serverEndPoint = new IPEndPoint(ipAddress, port);
            
            try
            {
                client.Connect(serverEndPoint);
            }
            catch (Exception e)
            {
                return false;
            }
            stream = client.GetStream();
            serverMessage = new Thread(getStreamAndDisplay);
            serverMessage.Start();
            return client.Connected;
        }
        /// <summary>
        /// Send Message- is used to send a chat message to the server. SendMessage first
        /// checks to see if a connection exists before trying to send message, if the connection 
        /// exists it sends the message if not it just returns false;
        /// 
        /// <param name="input">The user given chat message</param>
        /// <returns>A Boolean value that is true if the message sent and false if not connected</returns>
        /// </summary>
        public Boolean SendMessage(string input)
        {
            if (this.Connected() == false)
            {
                return this.Connected();
            }
            ASCIIEncoding encoder = new ASCIIEncoding();

            byte[] buffer = encoder.GetBytes("[message " + input + " ]\r\n");

            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();
            return true;
        }

        /// <summary>
        /// JoinSession- is used to join a session the chat server. JoinSession first
        /// checks to see if a connection exists before trying to send message, if the connection 
        /// exists it sends the message if not it just returns false;
        /// 
        /// <param name="input">The user given session to join or create</param>
        /// <returns>A Boolean value that is true if the message sent and false if not connected</returns>
        /// </summary>
        public Boolean JoinSession(string input)
        {
            if (this.Connected() == false)
            {
                return this.Connected();
            }

            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] buffer = encoder.GetBytes("[session " + input + " ]\r\n");
            
            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();
            return true;
        }

        /// <summary>
        /// getStreamAndDisplay - is meant to run on different thread than the current Connection object, 
        /// it handles the server's messages and parses them in strings with a specific type.
        /// 
        /// Type 0 being a message that is not parsed or displayed.
        /// Type 1 being a EXISTING_SESSION or STARTING_SESSION message
        /// Type 2 being a SESSION_MEMBER or JOINING_SESSION message
        /// Type 3 being a NAME message, it's ignored.
        /// Type 4 being a MESSAGE or chat message it's parsed with the user.
        /// Type 5 being a LEAVING_SESSION
        /// Type 6 being a ENDING SESSION
        /// Type 7 isn't created by this method but it represent a disconnect.
        /// 
        /// Once the message has been parsed, getStreamAndDisplay raises the didItChange method to 
        /// notify the listener that the server has a message for them and sends the message and type.
        /// </summary>
        private void getStreamAndDisplay()
        {
            //If the connection is ever lost finish the function and close the thread
            while (client.Connected == true)
            {
                if (formClose == true)
                {
                    return;
                }

                //Starting the buffer
                byte[] buffer = new byte[1024];
                try
                {
                    stream.Read(buffer, 0, 1024);
                }
                catch (Exception e)
                {
                    if (client.Connected == false)
                    {
                        Reconnect();
                    }
                }
                serverOut = "";
                foreach (byte i in buffer)
                {
                    //Removing empty spaces
                    if (i != 0)
                    {
                        //Placing together in string 
                        serverOut += (char)i;
                    }
                }
                //Decoding server messages

                while (serverOut.Contains("<") == true)
                {
                    type = 0;
                    //Checking to see if we have at least one complete command
                    while (serverOut.Contains(">") == false)
                    {
                        try
                        {
                            stream.Read(buffer, 0, 1024);
                        }
                        catch (Exception e)
                        {
                            if (client.Connected == false)
                            {
                                Reconnect();
                            }
                        }
                        //incomplete command, pulling next buffer adding to serverOut

                        foreach (byte i in buffer)
                        {
                            //Removing empty spaces
                            if (i != 0)
                            {
                                //Placing together in string 
                                serverOut += (char)i;
                            }
                        }
                    }
      

                    //Split off the server's input
                    if (serverOut.Equals("") == false)
                    {
                        int a = serverOut.IndexOf("<");
                        int b = serverOut.IndexOf(">");
                        temp = serverOut.Substring((b - a) + 3);
                        serverOut = serverOut.Substring(a, b - a + 1);
                        //Filtering input and setting a type
                        if (serverOut.Contains(" ") == true)
                        {
                            if (serverOut.Substring(1, serverOut.IndexOf(" ") - 1).Equals("EXISTING_SESSION") || serverOut.Substring(1, serverOut.IndexOf(" ") - 1).Equals("STARTING_SESSION"))
                            {
                                type = 1;
                                output = serverOut.Substring(serverOut.IndexOf(" ") + 1, serverOut.Length - serverOut.IndexOf(" ") - 2);
                            }
                            if (serverOut.Substring(1, serverOut.IndexOf(" ") - 1).Equals("SESSION_MEMBER") || serverOut.Substring(1, serverOut.IndexOf(" ") - 1).Equals("JOINING_SESSION"))
                            {
                              
                                type = 2;
                                output = serverOut.Substring(serverOut.IndexOf(" ") + 1, serverOut.Length - serverOut.IndexOf(" ") - 2);
                                if (sessions.Contains(output) == true)
                                {
                                    output = "";
                                }
                                else
                                {
                                    sessions.Add(output);
                                }

                            }
                            if (serverOut.Substring(1, serverOut.IndexOf(" ") - 1).Equals("MESSAGE"))
                            {
                                type = 4;
                                serverOut = serverOut.Substring(9, serverOut.Length - 10);
                                int right = serverOut.IndexOf(" ");

                                serverOut = serverOut.Substring(0, right + 1).Replace(" ", ": ") + serverOut.Substring(right, serverOut.Length - right);
                                serverOut = serverOut.Replace(">", "");
                                output = serverOut + "\r\n";
                            }
                            if (serverOut.Substring(1, serverOut.IndexOf(" ") - 1).Equals("NAME"))
                            {
                                type = 3;
                                output = "";
                                
                            }
                            if (serverOut.Substring(1, serverOut.IndexOf(" ") - 1).Equals("LEAVING_SESSION"))
                            {
                                type = 5;
                                output = serverOut.Substring(serverOut.IndexOf(" ") + 1, serverOut.Length - serverOut.IndexOf(" ") - 2);
                            }
                            if (serverOut.Substring(1, serverOut.IndexOf(" ") - 1).Equals("ENDING_SESSION"))
                            {
                                type = 6;
                                output = serverOut.Substring(serverOut.IndexOf(" ") + 1, serverOut.Length - serverOut.IndexOf(" ") - 2);
                                if (sessions.Contains(output) == true)
                                {
                                    sessions.Remove(output);
                                }
                                
                            }
                                 
                        }
                    }
                    state = true;
                    this.DidItChange();
                    serverOut = temp;
                }
            }

        }

        /// <summary>
        /// Reconnect - notifies the listener that the connection has been lost between 
        /// the connection object and the server to reconnect.
        /// 
        /// </summary>
        private void Reconnect()
        {
            if (formClose == false)
            {
                sessions.Clear();
                client.Close();

                //raising event to notify user to reconnect
                type = 7;
                state = true;
                this.DidItChange();
            }
        }

        /// <summary>
        /// GetIp -returns the ip address of the current connection object
        /// <returns>A string of the ip address and port</returns>
        /// </summary>
        public string GetIp()
        {
            return ipAddress.ToString() + ":" + port.ToString();
        }

        /// <summary>
        /// Reconnect - notifies the listener that the connection has been lost between 
        /// the connection object and the server to reconnect.
        /// <param name="input">User defined name to be sent to the server</param>
        /// </summary>
        public void SetName(string input)
        {
            name = input;
            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] buffer = encoder.GetBytes("[name " + name + "]\n");

            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();
        }

        /// <summary>
        /// GetName returns the username set for the current connection object.
        /// 
        /// <returns>The current username set for the connection object</returns>
        /// </summary>
        public string GetName()
        {
            return name;
        }

        /// <summary>
        /// Disconnect- safely closes the socket of the current connection object after 
        /// sending a quit message to the server. Lastly this method then notifies the 
        /// listener that the connection has been lost.
        /// 
        /// </summary>
        public void Disconnect()
        {
            //differing between Disconnect and DisconnectAndQuit
            if (formClose == false)
            {
                ASCIIEncoding encoder = new ASCIIEncoding();
                byte[] buffer = encoder.GetBytes("[QUIT]\r\n");
                stream.Write(buffer, 0, buffer.Length);
                stream.Flush();
                sessions.Clear();
                client.Close();
                //raising event to notify user to reconnect
                type = 7;
                state = true;
                this.DidItChange();
            }        
        }

        /// <summary>
        /// DisconnectandQuit- safely closes the socket of the current connection object after 
        /// sending a quit message to the server. This method is ran in tandum with the listener quiting, 
        /// so it doesn't notify the listener that the connection has been lost.
        /// 
        /// </summary>
        public void DisconnectAndQuit()
        {
            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] buffer = encoder.GetBytes("[QUIT]\r\n");

            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();
            formClose = true;
            client.Close();
        }

        /// <summary>
        /// LeaveSession - sends a message to the server that the current connection object would
        /// like to leave the session. No immediate messages are sent to the listener due to the
        /// getStreamAndDisplay already running if a good conneciton exists.
        /// 
        /// </summary>
        public void LeaveSession()
        {
            sessions.Clear();
            ASCIIEncoding encoder = new ASCIIEncoding();
            byte[] buffer = encoder.GetBytes("[Leave]\n");

            stream.Write(buffer, 0, buffer.Length);
            stream.Flush();
        }

    }
}

