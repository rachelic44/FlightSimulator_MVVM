using FlightSimulator.Model.Interface;
using FlightSimulator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class SimulatorModel : BaseNotify, ISimulatorModel
    {
        private ITelnetClient telnetClient;
        private Server server;
        private volatile Boolean stop;
        private double aileron;
    
        //properties that will be bined: 
        public double Aileron
        {
            get { return aileron; }
            set { aileron = value;
                NotifyPropertyChanged("Aileron"); 
            }
        }
        private double throttle;
        public double Throttle
        {
            get { return throttle; }
            set
            {
                throttle = value;
                NotifyPropertyChanged("Throttle");
            }
        }
        private double elevator;
        public double Elevator
        {
            get { return elevator; }
            set
            {
                elevator = value;
                NotifyPropertyChanged("Elevator");
            }
        }
        private double rudder;
        public double Rudder
        {
            get { return rudder; }
            set
            {
                rudder = value;
                NotifyPropertyChanged("Rudder");
            }
        }


        public SimulatorModel(ITelnetClient telnetClient)
        {
            this.telnetClient = telnetClient;
            stop = false;
        }

        public void connectAsClient(string ip, int port)
        {
            telnetClient.connect(ip, port);
        }

        public void disconnectAsClient()
        {
            stop = true;
            telnetClient.disconnect();
        }

        public void startClient()
        {
            new Thread(delegate () {  // not suppused to be in a thread. look at the c++ code.
                while (!stop)
                {
                    telnetClient.write("set controls/flight/rudder -1\r\n");
                    //# LeftSonar = Double.Parse(telnetClient.read());
                    // the same for the other sensors properties
                    Thread.Sleep(250);// read the data in 4Hz
                }
            }).Start();
        }


        public void openServer()
        {
           //nod needed, or separate.
        }

        public void startServer()
        {
            server.Start();
        }

        public void stopServer()
        {
            server.Stop();
        }

        //proprties : 


    }
}
