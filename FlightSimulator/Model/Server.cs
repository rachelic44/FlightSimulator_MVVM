using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
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
        string ip;
        private int port;
        private TcpListener listener;
        FlightBoardModel flightBoardModel;

        public Server(string ip, int port,FlightBoardModel flightBoardModel)
        {
            this.port = port;
            this.ip = ip;
            this.flightBoardModel = flightBoardModel;
         
        }

        public void Start()
        {
           


            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), port);
            listener = new TcpListener(ep);
            //can separate the open from the start todo

            listener.Start();
            Console.WriteLine("Waiting for connections...");
            
            Thread thread = new Thread(() => {

                //wait for a client to connect
                TcpClient client = listener.AcceptTcpClient();
                //todo : here to change the boolen that will raise the function of the model (or call the func).maybe the boolean needed to somwhere else 
                Console.WriteLine("Got new connection");

                /* change the boolean to true, to let know that the simulator is now opened,
                 * and can be connected to as a server */ 
                Connection.Instance.SimulatorOpened = true;

                BinaryReader reader = new BinaryReader(client.GetStream());
                var format = new NumberFormatInfo();
                format.NegativeSign = "-";
                format.NumberDecimalSeparator = ".";

                while (!Connection.Instance.StopReading) //change to boolan
                {
                    try
                    {
                        string input = "";
                        char s;
                        while ((s = reader.ReadChar()) != '\n')
                        {
                            input += s;
                        }
                       // Console.WriteLine("the values: {0}", input);
                        string[] ddata = input.Split(',');
                      //  Console.WriteLine("the one:{0}", ddata[0]);
                        flightBoardModel.Lon = double.Parse(ddata[0],format);
                        flightBoardModel.Lat = double.Parse(ddata[1],format);
                        string[] result = { ddata[0], ddata[1] };
                      //  Console.WriteLine("model change {0}, {1}", double.Parse(ddata[0], format), double.Parse(ddata[1], format));

                        //print up

                        /*get all the values from the simulator, put it in some map so the simulatormodel can 
                         * use it. evn better, create a client handler to *handle* it, so afterwards it will be easier
                         * to handle even more clients, not only the simulator. but mainly, thats the idea, like variable map that
                         * has been last semster, each of the is a property , so an invokation will rise and let the vie model know,
                         * so maybe not a map but a function to depart it and assign each property [ of the 4-5 needed] .*/

                        //System.Threading.Thread.Sleep(100);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Exception while reading from the simulator");
                        break;
                    }
                }
                Console.WriteLine("Server stopped");
                Stop(client);
            });
            thread.Start();
        }
        public void Stop(TcpClient client)
        {
            client.Close();
            listener.Stop();
        }
    }


}
