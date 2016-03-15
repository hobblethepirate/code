using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;        


namespace NetworkingClient
{
    //"REQ|"+time+"|"+messageID+"|"+username+"|"+studentNumber+"|"+messageDelay+"|" + info[0] + "|" + info[1] + "|" + client.Client.Handle.ToString() + "|" + ipAddress.ToString() + "|" + port + "|" + input + "|"+scenario+"|");

    public struct Message
    {
        public string type;
        public long time;
        public int messageID;
        public string username;
        public string studentNumber;
        public int messageDelay;
        public string clientIP;
        public string clientPort;
        public string handle;
        public string serverIP;
        public int serverPort;
        public int scenario;
        public string message;
        public int partnerMessage;
        public long receivedTime;
        public bool matched;
    }

    class Connection
    {
        private TcpClient client;
        private IPAddress ipAddress;
        private Thread serverMessage;
        private NetworkStream stream;
        private string serverOut = "";
        private int port;
        private int type = 0;
       // private string temp;
        private string output = "";
        public int sleepDelay=5000;

        public Boolean print = false;
        public int messageDelay = 0;
        public int messageID = 0;
        public String username = "ShaverJ";
        public String studentNumber = "20-9657";
        public String fileLocation = @"c:\temp\";
        public int scenario = 2;
        public Boolean state;
        public delegate void InfoEventHandler(String msg, int input);
        public event InfoEventHandler message;

        public Message[] recievedMessages = new Message[30000];
        public Message[] sentMessages = new Message[30000];

        
        private int currentRecievedMessage = 0;
        private int currentSentMessage=0;
        private String previous;
        private String incoming;
        private int transStartTime=0;
        private int transStopTime = 0;
        private String[] fileBuffer = new String[20];
        private int currentLine = 0;
        private static System.Timers.Timer aTimer;
        private static int time;
        private string rcvShutdownStatus="0";
        private string xmtShutdownStatus="0";
        private byte[] Buffer;
        private static System.Text.UTF8Encoding encoding = new System.Text.UTF8Encoding();
        private int currentSentString = 0;
        private String[] sentStrings = new String[20000];
        private int currentRecString = 0;
        private String[] recStrings = new String[20000];
        private int currentTransString = 0;
        private String[] transStrings = new String[40000];
        /// <summary>
        /// Connection Constructor - creates a connection object and starts it's event state 
        /// in false (no messages available)
        /// </summary>
        public Connection()
        {
            state = false;
            Buffer = new byte[1024];
            previous = "";
        }

        public Connection(String server, int port)
        {
            if (server.Length >= 7)
            {
                state = false;
                this.port = port;
                this.ipAddress = IPAddress.Parse(server);
            }
            Buffer = new byte[1024];
            previous = "";
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
                message(msg, type);
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
            aTimer = new System.Timers.Timer(1);
            // Hook up the Elapsed event for the timer. 

            aTimer.AutoReset = true;
            aTimer.Enabled = true;
            aTimer.Elapsed += OnTimedEvent;
          
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
            Thread.Sleep(2000);
            
            return client.Connected;
        }

        public Boolean StartConnectionThread()
        {
            client = new TcpClient();
            aTimer = new System.Timers.Timer(1);
            // Hook up the Elapsed event for the timer. 

            aTimer.AutoReset = true;
            aTimer.Enabled = true;
            aTimer.Elapsed += OnTimedEvent;
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
        private static void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            time = (e.SignalTime.Minute * 60000) + (e.SignalTime.Second * 1000) + e.SignalTime.Millisecond;

        }
        /// <summary>
        /// Send Message- is used to send a chat message to the server. SendMessage first
        /// checks to see if a connection exists before trying to send message, if the connection 
        /// exists it sends the message if not it just returns false;
        /// 
        /// <param name="input">The user given chat message</param>
        /// <returns>A Boolean value that is true if the message sent and false if not connected</returns>
        /// </summary>
        public Boolean SendReqMessage(string input)
        {
            if (this.Connected() == false)
            {
                return this.Connected();
            }
            ASCIIEncoding encoder = new ASCIIEncoding();
            if (currentSentMessage == 0) 
            {
                transStartTime = time;
            }

            String[] info = client.Client.LocalEndPoint.ToString().Split(':');
            int tempTime = time;
            byte[] buffer = encoder.GetBytes("REQ|" + tempTime + "|" + messageID + "|" + username + "|" + studentNumber + "|" + messageDelay + "|" + info[0] + "|" + info[1] + "|" + client.Client.Handle.ToString() + "|" + ipAddress.ToString() + "|" + port + "|" + input + "|" + scenario + "|");
            
            sentMessages[currentSentMessage].type = "REQ";
            sentMessages[currentSentMessage].time = tempTime;
            sentMessages[currentSentMessage].messageID = messageID;
            sentMessages[currentSentMessage].username = username;
            sentMessages[currentSentMessage].studentNumber = studentNumber;
            sentMessages[currentSentMessage].messageDelay = messageDelay;
            sentMessages[currentSentMessage].clientIP = info[0];
            sentMessages[currentSentMessage].clientPort = info[1];
            sentMessages[currentSentMessage].handle = client.Client.Handle.ToString();
            sentMessages[currentSentMessage].serverIP = ipAddress.ToString();
            sentMessages[currentSentMessage].serverPort = port;
            sentMessages[currentSentMessage].message = input;
            sentMessages[currentSentMessage].scenario = scenario;
            sentMessages[currentSentMessage].receivedTime = 0;
            sentMessages[currentSentMessage].matched = false;
            currentSentMessage++;
            byte tcpHeader0 = 0;

            byte tcpHeader1 = Convert.ToByte(buffer.Length);
            var result = new byte[buffer.Length + 2];

            result[0] = tcpHeader0;
            result[1] = tcpHeader1;
            int a = 2;
            foreach (Byte i in buffer)
            {
                result[a] = i;
                a++;
            }
            if (print == true)
            {
                Console.WriteLine("Client: " + System.Text.Encoding.UTF8.GetString(result));
            }
            transStrings[currentTransString]= System.Text.Encoding.UTF8.GetString(result);
            currentTransString++;
           
            stream.WriteAsync(result, 0, result.Length);
            stream.Flush();
            return true;
        }





        private void getStreamAndDisplay()
        {

            byte[] header = new Byte[2];
            short length;
            Boolean finished;
            String result;
            //If the connection is ever lost finish the function and close the thread
            while (client.Connected == true)
            {
                Buffer = new byte[1024];
                try
                {
                    stream.Read(Buffer, 0, 1024);
                }
                catch (Exception) 
                {
                    if (client.Connected == false) 
                    {
                        Reconnect();
                    }
                }
                length = 0;
                header = new Byte[2];
                incoming = "";
                result = "";
                incoming = encoding.GetString(Buffer,0,Buffer.Length);
                if (string.IsNullOrWhiteSpace(previous) == false)
                {
                    incoming = previous + incoming;
                    previous = "";
                }
                if (incoming.Contains("RSP") == false) 
                {
                    Console.WriteLine("Server: sent unreadable message, throwing out: " + incoming);
                    return;
                }
                finished = false;
                while (finished==false)
                {
                    result = "";
                    header[0] = (byte)incoming[0];
                    header[1] = (byte)incoming[1];
                    if (BitConverter.IsLittleEndian)
                        Array.Reverse(header);

                    length = BitConverter.ToInt16(header, 0);


                    if (length > 1000) 
                    {
                        
                        throw new Exception("Bad length given to parse");
                    }
                    if (length == 0)
                    {
                        break;
                    }
                    try
                    {
                        result = incoming.Substring(0, length + 2);
                    }
                    catch (System.ArgumentOutOfRangeException) 
                    {
                        previous = incoming;
             
                        finished = true;
                        break;
                    }
                   
                    try
                    {
                        incoming = incoming.Substring(length + 2);
                        if (result.Substring(10).Contains("RSP") == true) 
                        {
                            throw new Exception("Two responses in same string exception");
                        }

                        if (result[result.Length-1] != '|') 
                        {
                            result = result + "|";
                            
                        }
                        CheckOffMessage(result.Split('|'));
                        
                        Console.WriteLine("Server: " + result);
                        transStrings[currentTransString] = result;
                        currentTransString++;
                        result = "";
                        
                    }
                    catch (System.ArgumentOutOfRangeException) 
                    {
                        previous = incoming;
                        finished = true;
                        break;
                      
                    }
                    if (incoming.Length ==0) 
                    {
                        finished = true;
                        break;
                    }
                    if (incoming.Length == 1) 
                    {
                        previous = incoming;
                        finished = true;
                        break;
                        
                    }
                    
                    if (incoming[0] == '\0' && incoming[1] == '\0') 
                    {
                        finished = true;
                        break;
                    }
                    
                }
                output = "";
                state = true;
                this.DidItChange();


            }
        }
        private void CheckOffMessage(string[] results)
        {
            try
            {
                recievedMessages[currentRecievedMessage].type = results[0];
                recievedMessages[currentRecievedMessage].time = Convert.ToInt64(results[1]);
                recievedMessages[currentRecievedMessage].messageID = Convert.ToInt32(results[2]);
                recievedMessages[currentRecievedMessage].username = results[3];
                recievedMessages[currentRecievedMessage].studentNumber = results[4];
                recievedMessages[currentRecievedMessage].messageDelay = Convert.ToInt32(results[5]);
                recievedMessages[currentRecievedMessage].serverIP = results[6];
                recievedMessages[currentRecievedMessage].serverPort = Convert.ToInt32(results[7]);
                recievedMessages[currentRecievedMessage].handle = results[8];
                recievedMessages[currentRecievedMessage].serverIP = results[9];
                recievedMessages[currentRecievedMessage].serverPort = Convert.ToInt32(results[10]);
                recievedMessages[currentRecievedMessage].message = results[11];
                recievedMessages[currentRecievedMessage].scenario = -1;
                recievedMessages[currentRecievedMessage].receivedTime = time;
                recievedMessages[currentRecievedMessage].matched = false;
                currentRecievedMessage++;
            }
            catch (Exception) 
            {
                Console.WriteLine("Throwing out a line");
             
            }

            
        }

        /// <summary>
        /// Reconnect - notifies the listener that the connection has been lost between 
        /// the connection object and the server to reconnect.
        /// 
        /// </summary>
        private void Reconnect()
        {
            if (currentSentMessage != currentRecievedMessage)
            {
                Console.WriteLine("Disconnected.. Attempting to reconnect in 3 seconds");
                Thread.Sleep(3000);
                StartConnectionThread();
                if (client.Connected == false) 
                {
                    Console.WriteLine("Unable to connect.. exiting");
                    DisconnectAndQuit();
                }
            }
        }

        public void SendDisconnect() 
        {
            serverMessage.Abort();
            try
            {
                client.Client.Shutdown(SocketShutdown.Send);
            }
            catch (Exception e)
            {
                xmtShutdownStatus = e.Data.ToString();
            }
            try
            {

                client.Client.Shutdown(SocketShutdown.Receive);
            }
            catch (Exception e) 
            {
                rcvShutdownStatus = e.Data.ToString();
            }
        }
        public void SendReqAndWait(String message) 
        {
           
            SendReqMessage(message);
            int temp = currentSentMessage;
            while (temp == currentSentMessage) 
            {

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
            client.Close();
            aTimer.Stop();
            aTimer.Dispose();

            //output file

            using (System.IO.StreamWriter file =
            new System.IO.StreamWriter(fileLocation + @"Lab3.txt"))
            {
                //byte[] buffer = encoder.GetBytes("REQ|" + tempTime + "|" + messageID + "|" + username + "|" + studentNumber + "|" + messageDelay + "|" + info[0] + "|" + info[1] + "|" + client.Client.Handle.ToString() + "|" + ipAddress.ToString() + "|" + port + "|" + input + "|" + scenario + "|");
                int counting= 0;
                foreach(string item in transStrings)         
                {
                    if (string.IsNullOrEmpty(item) == false)
                    {
                        file.WriteLine(item);
                    }
                }
     
                System.Text.StringBuilder sb = new System.Text.StringBuilder();
                sb.Append(System.DateTime.Now.ToString("MMddyyyy"));
                sb.Append("|");
                sb.Append(System.DateTime.Now.ToString("HHmmss"));
                sb.Append("|");
                file.WriteLine(sb.ToString());
                foreach (string line in fileBuffer)
                {
                    if (String.IsNullOrEmpty(line)==false)
                    {
                        file.WriteLine(line);
                    }
                }

                file.Close();              
            }
        }

        public void sendReqsAndWait(int quantity, string message)
        {
            int temp = currentSentMessage;
            for (int a = 1; a <= quantity; a++)
            {

                messageID = a;
                SendReqMessage(message);
            }
            string b = null;
            //while (currentMessage!=quantity*2) 
            //{
               
            //}
            SendDisconnect();
            DisconnectAndQuit();
            
        }


        public void sendAsyncReqsAndWait(int quantity, string message)
        {
            int matched = 0;
            fileBuffer[currentLine] = "Requests transmitted = [" + quantity + "]";
            currentLine++;

            for (int a = 1; a <= quantity; a++)
            {

                messageID = a;
                SendReqMessage(message);


            }
            int current = 0;

            Thread.Sleep(sleepDelay);


            transStopTime = time;
            
            CheckAllMessages();

        }

        public String[] Split(String chars, String line) 
        {
            return line.Split(new string[] { chars }, StringSplitOptions.None);
        }

        public void CheckAllMessages()
        {
            long firstMessageSentTime = 0;
            long lastMessageSentTime = 0;
            long firstMessageReceivedTime = 0;
            long lastMessageReceivedTime = 0;
            int responseCount = 0;
            int responseTotal = 0;
            int requestTotal = 0;
            int requestCount = 0;

            Console.WriteLine("Sent: " + currentSentMessage + " Received: " + currentRecievedMessage);
            Console.WriteLine("First message ID recieved: " + recievedMessages[0].messageID);
            try
            {
                Console.WriteLine("Last message ID recieved: " + recievedMessages[currentRecievedMessage - 1].messageID);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine("No messages were recieved in the delayed amount of time");
                return;
            }
            firstMessageReceivedTime = recievedMessages[0].receivedTime;
            lastMessageReceivedTime = recievedMessages[currentRecievedMessage - 1].receivedTime;
            firstMessageSentTime = sentMessages[0].time;
            lastMessageSentTime = sentMessages[currentSentMessage - 1].time;

            long requestDuration = 0, responseDuration = 0;
            fileBuffer[currentLine] = "Responses received = [" + currentRecievedMessage + "]";
            Console.WriteLine(fileBuffer[currentLine]);
            currentLine++;
            requestDuration = (lastMessageSentTime - firstMessageSentTime);
            fileBuffer[currentLine] = "Req. run duration (ms) = [" + requestDuration + "]";
            Console.WriteLine(fileBuffer[currentLine]);
            currentLine++;
            responseDuration = (lastMessageReceivedTime - firstMessageReceivedTime);
            fileBuffer[currentLine] = "Rsp. run duration (ms) = [" + responseDuration + "]";
            Console.WriteLine(fileBuffer[currentLine]);
            currentLine++;
            fileBuffer[currentLine] = "Trans. Duration (ms) = [" + (transStopTime - transStartTime) + "]";
            Console.WriteLine(fileBuffer[currentLine]);
            currentLine++;
            fileBuffer[currentLine] = "Actual req. pace (ms) = [" + (float)(requestDuration / currentSentMessage) + "]";
            Console.WriteLine(fileBuffer[currentLine]);
            currentLine++;
            if (currentRecString == 0)
            {
                fileBuffer[currentLine] = "Actual rsp. Pace (ms) = [" + 0 + "]";
            }
            else
            {
                fileBuffer[currentLine] = "Actual rsp. Pace (ms) = [" + (float)(responseDuration / currentRecievedMessage) + "]";
            }
            Console.WriteLine(fileBuffer[currentLine]);
            currentLine++;
            fileBuffer[currentLine] = "Configured pace (ms) = [" + messageDelay + "]";
            Console.WriteLine(fileBuffer[currentLine]);
            currentLine++;

            // calculate the transaction average

            int tranAvg = (transStopTime - transStartTime) / currentRecievedMessage;
            fileBuffer[currentLine] = "Transaction avg. (ms) = [" + tranAvg + "]";
            Console.WriteLine(fileBuffer[currentLine]);

            currentLine++;
            fileBuffer[currentLine]="Your name:";
            currentLine++;
            fileBuffer[currentLine] = "Name of student whose client was used: James Shaver";
            currentLine++;
        }

        private int FindReqMessage(int id) 
        {
            for (int count = 0; count <= currentRecievedMessage; count++) 
            {
                if (recievedMessages[count].receivedTime != 0 && recievedMessages[count].messageID == id)
                {
                    recievedMessages[count].matched = true;
                    return count;
                }
               
            }

            return -1;
        }

        public void SendResponseMessage(String message, int id)
        {
             if (this.Connected() == false)
             {
                 return;
             }
             ASCIIEncoding encoder = new ASCIIEncoding();
            
            
             String[] info = client.Client.LocalEndPoint.ToString().Split(':');

             byte[] buffer = encoder.GetBytes("RSP|" + time + "|" + id + "|" + username + "|" + studentNumber + "|" + messageDelay + "|" + ipAddress.ToString() + "|" + port + "|" + client.Client.Handle.ToString() + "|" + info[0] + "|" + info[1] + "|" + id+"-1" + "|2|");
             byte tcpHeader0 = 0;
            
             byte tcpHeader1 = Convert.ToByte(buffer.Length);
             var result = new byte[buffer.Length + 2];
            
             result[0] = tcpHeader0;
             result[1] = tcpHeader1;
             int a = 2;
             foreach (Byte i in buffer)
             {
                 result[a] = i;
                 a++;
             }
             
            
             stream.Write(result, 0, result.Length);
            
             stream.Flush();
             
        }
    }
}

