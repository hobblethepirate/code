using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

//written by James Shaver, October 2011 for Cs 3500 PS6

namespace ChatGUI
{
    /// <summary>
    /// Form1- is the Controller portion of the MVC model that is meant to act as communication point
    /// between the Model and the View (Form1 Design view). It creates a connection object current and
    /// places a listener on it (DisplayNotification) to handle messages from the connection object. Form1
    /// also reorganizes the view depending upon the connection object's messages. Form1 contains no 
    /// connection/socket code. The Form1 code also doesn't allow the view to know of Model(connection).
    /// 
    /// </summary>
    public partial class Form1 : Form
    {
        //Creating an instance between
        Connection current = new Connection();
        Boolean started = false;
        ListBox listBox3 = new ListBox();
        public Form1()
        {
            InitializeComponent();

            //Connecting Controller to the Model
            current.message += DisplayNotification;

            //Prompting user for input need to connect
            string hostName = Microsoft.VisualBasic.Interaction.InputBox("Please enter a host name to connect to followed by a : and port: (ex. 127.0.0.1:4000)", "Session", current.GetIp(), 150, 150);

            Boolean started = current.StartConnectionThread(hostName);
            while (started != true)
            {
                hostName = Microsoft.VisualBasic.Interaction.InputBox("Unable to Connect. Please enter a valid host name to connect to followed by a : and port: (ex. 127.0.0.1:4000)", "Unable to Connect", current.GetIp(), 150, 150);
                started = current.StartConnectionThread(hostName);
            }
            string userName = Microsoft.VisualBasic.Interaction.InputBox("Connection Succeeded. Please enter a username:", "Session", current.GetName(), 150, 150);
            current.SetName(userName);
            
        }

        /// <summary>
        /// DisplayNotification- method triggered when the listener is triggered by the connection object. 
        /// If the form is already started or displayed the displayNotification thread will send messages 
        /// through invoke. Either way it calls the ChangeText method.
        /// <param name="msg">Message recieved by the connection object</param>
        /// <param name="type">Type of message recieved by the connection object</param>
        /// </summary>
        private void DisplayNotification(String msg, int type)
        {
            if (started == true && current.Connected()==true)
            {
                Action op = () => this.changeText(type, msg);
                this.Invoke(op);

            }
            else
            {
                this.changeText(type, msg);
            }
        }

        /// <summary>
        /// ChangeText- interprets connection method's message and changes specific parts of
        /// the View to show the current state of the server. Messages 0 and 3 are ignored due
        /// to having no use for the View.
        /// 
        /// It being the message (msg)
        /// Type 1: adding it to SessionList object in the view
        /// Type 2: adding it to listbox1 (user list)
        /// Type 4: adding it to the main chat box
        /// Type 5: removing it from the listbox1 (user list) 
        /// Type 6: removing it to SessionList object in the view
        /// Type 7: reconnecting no message use.
        /// 
        /// <param name="msg">Message sent from the connection object to the controller</param>
        /// <param name="type">Type of message sent from the connection object</param>
        /// </summary>
        private void changeText(int type, string msg)
        {
            //Server message being split up by type
            switch (type)
            {
                case 1:
                    SessionList.Items.Add(msg);
                    break;
                case 2:
                    listBox1.Items.Add(msg);
                    break;
                //Type 3 is just <NAME ...>, ignoring due to no real use
                case 4:
                    textBox1.Text += msg;
                    break;
                case 5:
                    listBox1.Items.Remove(msg);
                    break;
                case 6:
                    SessionList.Items.Remove(msg);
                    break;
                case 7:
                    GetInfoToReconnect();
                    break;
            }
        }



        private void Form1_Load_1(object sender, EventArgs e)
        {
            //notifies DisplayNotification that the form is visible
            started = true;
        }


        /// <summary>
        /// Button1_Click_1-is the join session button, it utilizes the connection object to join it to a session. 
        /// Button1_Click_1 then changes the view to a Chat view once connected.
        /// </summary>
        private void button1_Click_1(object sender, EventArgs e)
        {
            string selected = SessionList.SelectedItem.ToString();
            if (selected.Equals("Add New") == true)
            {
                selected = Microsoft.VisualBasic.Interaction.InputBox("Please enter a new session name:", "Session", "New Session", 150, 150);
            }

            //sending message to the connection object
            current.JoinSession(selected);

            //changing the view to a chat view instead of a session view
            textBox1.Text = "[ Welcome to the " + selected + " Session]\r\n";
            SessionList.Visible = false;
            button1.Visible = false;
            label1.Visible = false;
            button2.Visible = true;
            button3.Visible = true;
            textBox2.Visible = true;
            textBox1.Visible = true;
            splitContainer1.Visible = true;
            listBox1.Visible = true;
        }
        /// <summary>
        /// Button2_Click_1-is the Send button, it sends a chat message to the connection object.
        /// </summary>
        private void button2_Click_1(object sender, EventArgs e)
        {
            current.SendMessage(textBox2.Text);
            //clearing textbox
            textBox2.Text = "";
        }

        /// <summary>
        /// Button3_Click - is the Leave Session button, it sends a leave message to the current 
        /// connection object and then changes the view from a chat view to a session view.
        /// </summary>
        private void button3_Click(object sender, EventArgs e)
        {
            //sending a leave message to the current connection object
            current.LeaveSession();

            //Changing from a chat view to a session view
            SessionList.Visible = true;
            button1.Visible = true;
            label1.Visible = true;
            button2.Visible = false;
            button3.Visible = false;
            textBox2.Visible = false;
            textBox1.Visible = false;
            
            splitContainer1.Visible = false;
            listBox1.Visible = false;
            listBox1.Items.Clear();
            textBox1.Text = "";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Disposing of Current Connection Thread
            current.DisconnectAndQuit();
            //Closing Form
            this.Close();
        }
        private void Form1_Closed(object sender, System.EventArgs e)
        {
            current.DisconnectAndQuit();
        }

        /// <summary>
        /// GetInfoToReconnect - is triggered by connection object message of type 7 it
        /// changes the view to a disconnected view
        /// </summary>
        private void GetInfoToReconnect()
        {
            //going from an unknown view to a disconnected view
            SessionList.Visible = false;
            button1.Visible = false;
            label1.Visible = false;
            button2.Visible = false;
            button3.Visible = false;
            textBox2.Visible = false;
            textBox1.Visible = false;
            listBox1.Visible = false;
            button4.Visible = true;
        }

        private void disconnectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            current.Disconnect();
        }

        /// <summary>
        ///Button4Click- is the trigger portion of the reconnect process, it changes the
        ///view to the sessionList view once connnected. 
        /// </summary>
        private void button4_Click(object sender, EventArgs e)
        {
            //Prompting user for reconnect
            string hostName = Microsoft.VisualBasic.Interaction.InputBox("Please enter a host name to connect to followed by a : and port: (ex. 127.0.0.1:4000)", "Session", current.GetIp(), 150, 150);
            
            listBox1.Items.Clear();
            SessionList.Items.Clear();
            SessionList.Items.Add("Add New");
            Boolean started = current.StartConnectionThread(hostName);
            while (started != true)
            {
                hostName = Microsoft.VisualBasic.Interaction.InputBox("Unable to Connect. Please enter a valid host name to connect to followed by a : and port: (ex. 127.0.0.1:4000)", "Unable to Connect", current.GetIp(), 150, 150);
                started = current.StartConnectionThread(hostName);
            }
            string userName = Microsoft.VisualBasic.Interaction.InputBox("Connection Succeeded. Please enter a username:", "Session", current.GetName(), 150, 150);
            //Sending a message to the current connection object
            current.SetName(userName);

            //Changing view from disconnected to sessionList
            SessionList.Visible = true;
            button1.Visible = true;
            label1.Visible = true;
            button2.Visible = false;
            button3.Visible = false;
            textBox2.Visible = false;
            textBox1.Visible = false;
            button3.Visible = false;
            button4.Visible = false;
            splitContainer1.Visible = false;
            listBox1.Visible = false;           
            textBox1.Text = "";
        }
    }
}
