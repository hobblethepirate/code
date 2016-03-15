using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace NetworkingClient
{
    class Program
    {
        static void Main(string[] args)
        {
            String server = "127.0.0.1", port = "4000", username = "ShaverJ", studentNumber = "11-1111", fileLocation = @"C:\\temp";
            Connection main = new Connection();
            Connection second = new Connection();
            main.print = true;
            second.print = true;

            int quantity = 10000;
            int delay = 0;
            int sleepDelay = 0;
            string type = "async";

            if (args.Length != 0)
            {
                foreach (string arg in args)
                {
                    String[] splitArg = arg.Split(' ');
                    switch (splitArg[0])
                    {
                        case "-ip":
                            //ip address of the server
                            server = splitArg[1];
                            break;
                        case "-p":
                            //port of the server
                            port = splitArg[1];
                            break;
                        case "-dir":
                            //directory to save log files
                            fileLocation = splitArg[1];
                            break;
                        case "-d":
                            //delay
                            try
                            {
                                delay = Convert.ToInt32(splitArg[1]);
                            }
                            catch (Exception)
                            {

                            }
                            break;
                        case "-q":
                            try
                            {
                                quantity = Convert.ToInt32(splitArg[1]);
                            }
                            catch (Exception)
                            {

                            }
                            break;
                        case "-t":
                            type = splitArg[1];
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Please enter a server ip address: (the default is 127.0.0.1)");
                server = Console.ReadLine();
                if (String.IsNullOrEmpty(server) == true)
                {
                    server = "127.0.0.1";
                }
                Console.WriteLine("Please enter a server port: (the default is 4000)");
                port = Console.ReadLine();
                if (String.IsNullOrEmpty(port) == true)
                {
                    port = "4000";
                }
                username = "ShaverJ";


                studentNumber = "11-1111";
                Console.WriteLine("Please type in a file location for the log files to be saved: (the default is c:\\temp)");
                fileLocation = Console.ReadLine();
                if (String.IsNullOrEmpty(fileLocation) == true)
                {
                    fileLocation = @"C:\temp\";
                }

                Console.WriteLine("How many messages do you want to send? (The default is 10000)");
                try
                {
                    quantity = System.Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    quantity = 10000;
                }
                Console.WriteLine("What would you like the server side delay to be in milliseconds? (the default is 0)");
                try
                {
                    delay = System.Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    delay = 0;
                }

                if (delay > 4000) 
                {
                    Console.WriteLine("4000 ms is the maximum server side delay, sending with 4000 ms");
                    delay = 4000;
             
                }
                Console.WriteLine("How long do you want to wait in milliseconds for all the messages to arrive ? (default is 5000 milliseconds, this does effect the transaction duration)");

                try
                {
                    sleepDelay = System.Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception)
                {
                    sleepDelay = 5000;
                }
                second.sleepDelay = sleepDelay;

            }

            Console.WriteLine("Sending messages asynchronously");
            second.scenario = 1;
            second.fileLocation = fileLocation;
            second.messageDelay = delay;
            second.studentNumber = studentNumber;
            second.username = username;
            if (String.Compare(server, "") != 0 || String.Compare(port, "") != 0)
            {
                String item = server + ":" + port;
                second.StartConnectionThread(item);
            }
            else
            {
                second.StartConnectionThread();
            }

            if (second.Connected() == false)
            {

                Console.WriteLine("Unable to connect to " + server + " Please make sure your server is running.");
                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                return;
            }
            else
            {
                Console.WriteLine("Successfully connected.");
            }
            second.sendAsyncReqsAndWait(quantity, "hi");
            second.SendDisconnect();
            second.DisconnectAndQuit();
            Console.WriteLine("Completed");
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }


    }
}

    