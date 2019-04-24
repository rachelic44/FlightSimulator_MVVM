using FlightSimulator.Model.Interface;
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
    class MyTelnetClient : ITelnetClient {

        private TcpClient client;
        private BinaryWriter writer;
        private bool isConnect = false;
        public string Meassegae
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
        }

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
                this.isConnect = true;
                client.Connect(ep); //m add if failed - throw.. 
                Console.WriteLine("client connected to simulator ");
                //  this.stream = this.client.GetStream() ;
                this.writer = new BinaryWriter(this.client.GetStream());
                write("set controls/flight/rudder -1\r\n");
                write("set controls/flight/aileron -1\r\n");
            //    write("set controls/flight/rudder -1\r\n");

            });
            thread.Start();

        }
        public void write(string command)
        {
            Console.WriteLine("writing {0}",command);
      
                /* Send data to server */
                writer.Write(Encoding.ASCII.GetBytes(command));
                // Get result from server
            //    int result = reader.ReadInt32();
        
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
