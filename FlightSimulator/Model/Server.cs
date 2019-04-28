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
    /* THE INFO CLASS */
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
            /* Start the server */
            IPEndPoint ep = new IPEndPoint(IPAddress.Parse(ip), port);
            listener = new TcpListener(ep); 
            listener.Start();

            /* Wait for the connections in another thread, so the programm will continue running. */
            Thread thread = new Thread(() => {

                /* wait for a client to connect*/
                TcpClient client = listener.AcceptTcpClient();

                /* change the boolean to true, to let know that the simulator is now opened,
                 * and can be connected to as a server */ 
                Connection.Instance.SimulatorOpened = true;

                BinaryReader reader = new BinaryReader(client.GetStream());
                /* creat a format to read also negative numbers */
                var format = new NumberFormatInfo();
                format.NegativeSign = "-";
                format.NumberDecimalSeparator = ".";

                /* As long as we arre soppused to keep reading, read the values from the siulator */
                while (!Connection.Instance.StopReading) 
                {
                    try
                    {
                        string input = "";
                        char s;
                        while ((s = reader.ReadChar()) != '\n')
                        {
                            input += s;
                        }
                        string[] ddata = input.Split(',');
                        flightBoardModel.Lon = double.Parse(ddata[0],format);
                        flightBoardModel.Lat = double.Parse(ddata[1],format);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Exception while reading from the simulator");
                        break;
                    }
                }
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
