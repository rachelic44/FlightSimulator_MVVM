using FlightSimulator.Model.Interface;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class MyTelnetClient : ITelnetClient {

        private TcpClient client;
        private NetworkStream stream;
        private BinaryWriter writer;

        public void connect(string ip, int port)
        {
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), port);
            TcpClient client = new TcpClient();
            this.client = client;
            client.Connect(ep);
            Console.WriteLine("connected");
            this.stream = this.client.GetStream() ;
            this.writer= new BinaryWriter(this.stream);

        }
        public void write(string command)
        {
            Console.WriteLine(command);
      
                // Send data to server
              //  Console.Write("Please enter a number: ");
              //  int num = int.Parse(Console.ReadLine());
                writer.Write(command);
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
