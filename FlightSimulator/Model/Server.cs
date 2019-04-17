using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class Server
    {
        private int port;
        private TcpListener listener;
   
        public Server(int port)
        {
            this.port = port;
         
        }
        public void Start()
        {
            IPEndPoint ep = new
            IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
            listener = new TcpListener(ep);

            //can separate the open from the start todo

            listener.Start();
            Console.WriteLine("Waiting for connections...");
            Thread thread = new Thread(() => {
                while (true)
                {
                    try
                    {
                        TcpClient client = listener.AcceptTcpClient();
                        Console.WriteLine("Got new connection");
                        /*get all the values from the simulator, put it in some map so the simulatormodel can 
                         * use it. evn better, create a client handler to *handle* it, so afterwards it will be easier
                         * to handle even more clients, not only the simulator. but mainly, thats the idea, like variable map that
                         * has been last semster, each of the is a property , so an invokation will rise and let the vie model know,
                         * so maybe not a map but a function to depart it and assign each property [ of the 4-5 needed] .*/
                    }
                    catch (SocketException)
                    {
                        break;
                    }
                }
                Console.WriteLine("Server stopped");
            });
            thread.Start();
        }
        public void Stop()
        {
            listener.Stop();
        }
    }


}
