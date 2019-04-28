using FlightSimulator.Model.Interface;
using FlightSimulator.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class MyTelnetClient : ITelnetClient
    {

        private TcpClient client;
        private BinaryWriter writer;
        private Queue<string> commandsQueue; 

        public MyTelnetClient()
        {
            this.commandsQueue = new Queue<string>();
        }
     /*   public string Meassegae
        {
            set
            {
                Console.WriteLine("bh");
                Console.WriteLine(value);
                if (isConnect)
                {
                    this.write(value);
                }
            }
        }*/

        public void connect(string ip, int port)
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), port);
            TcpClient client = new TcpClient();
            this.client = client;

            Thread thread = new Thread(() => {

                while (!Connection.Instance.SimulatorOpened)
                {
                    Thread.Sleep(100);
                }
                client.Connect(ep); //m add if failed - throw.. 
                Console.WriteLine("client connected to simulator ");
                //  this.stream = this.client.GetStream() ;
                this.writer = new BinaryWriter(this.client.GetStream());
                while(!Connection.Instance.StopReading)
                {

                    while(commandsQueue.Count > 0)
                    {
                        writer.Write(Encoding.ASCII.GetBytes(commandsQueue.Peek()));
                        writer.Flush();
                        Console.WriteLine("wrote {0}", commandsQueue.Peek());
                        commandsQueue.Dequeue();
                    }
                }
            });
            thread.Start();
        }
        public void write(string command)
        {
            if (!Connection.Instance.StopReading)
            {
                Console.WriteLine("got {0}", command);

                this.commandsQueue.Enqueue(command);
                Console.WriteLine("pushed");
            } 

        }

        public string read() // blocking call. //supposed not to be used in this assignment, FG writes to server only?
        {
            return "";
        }

        public void disconnect()
        {
            client.Close();
        }
    }

}
