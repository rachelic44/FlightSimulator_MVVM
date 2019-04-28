using FlightSimulator.Model.Interface;
using FlightSimulator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    public class FlightBoardModel : BaseNotify
    {
        private double? lat;
        private double? lon;

        public void OpenConnections()
        {
            ISettingsModel app = ApplicationSettingsModel.Instance;
            Connection.Instance.StopReading = false;
            string ip = app.FlightServerIP;
            int portServer = app.FlightInfoPort;
            int portClient = app.FlightCommandPort;
            Server server = new Server(ip, portServer,this);
            server.Start();
            /* tell the connection class to create a connection , will happen only when the simulator is opened */ 
            Connection.Instance.createClient(ip,portClient); 
        }


        public double? Lat
        {
            get { return this.lat; }
            set
            {
                this.lat = value;
                NotifyPropertyChanged("Lat");
            }
        }

        // property Lon .
        public double? Lon
        {
            get { return this.lon; }
            set
            {
                this.lon = value;
                NotifyPropertyChanged("Lon");
            }
        }

        public void CloseConnections()
        {
            Connection.Instance.StopReading = true;
            Connection.Instance.SimulatorOpened = false;
        }
    }
}
