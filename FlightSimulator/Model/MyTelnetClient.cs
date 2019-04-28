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

        public void connect(string ip, int port)
        {
            /* creat a TCP client to write message to the simulator with */
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), port);
            TcpClient client = new TcpClient();
            this.client = client;

            Thread thread = new Thread(() => {

                /* make sure to not start writing before the simulator is opened */
                while (!Connection.Instance.SimulatorOpened)
                {
                    Thread.Sleep(100);
                }
                /* the simulator is opened , connect */
                client.Connect(ep); //add fail cheecl TODO
                this.writer = new BinaryWriter(this.client.GetStream());

                /* make a loop, as long as not StopReading, write meassages to the simulator */
                while(!Connection.Instance.StopReading)
                {
                    /* for each command in the command queue, write it */
                    while(commandsQueue.Count > 0)
                    {
                        try
                        {
                            writer.Write(Encoding.ASCII.GetBytes(commandsQueue.Peek()));
                            writer.Flush();
                            commandsQueue.Dequeue();

                        } catch (Exception) {

                            break;
                        }
                    }
                }
                disconnect();
            });
            thread.Start();
        }
        public void write(string command)
        {
            if (!Connection.Instance.StopReading)
            {
                this.commandsQueue.Enqueue(command);
            } 

        }

        public string read() 
        {
            return "";
        }

        public void disconnect()
        {
            client.Close();
        }
    }

}
