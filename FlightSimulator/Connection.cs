using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using FlightSimulator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator
{
    class Connection : BaseNotify
    {
        private Connection() 
        {

        }

        private ITelnetClient telnetClient;
        private bool simulatorOpened = false;
        private bool stopReading = false;

   
        public bool SimulatorOpened
        {
            get { return this.simulatorOpened;  }
            set { this.simulatorOpened = value; }
        }
       
        public bool StopReading
        {
            get { return this.stopReading; }
            set { this.stopReading = value; }
        }

        #region Singleton
        private static Connection m_Instance = null;
        public static Connection Instance
        {
            get
            {
                if (m_Instance == null)
                {
                    m_Instance = new Connection();
                }
                return m_Instance;
            }
        }


        public void createClient(string ip, int port)
        {
            ITelnetClient telnetClient = new MyTelnetClient();
            this.telnetClient = telnetClient;
            telnetClient.connect(ip, port);
        }

        public void AskClientToWrite(string message)
        {
           if(!this.simulatorOpened) //TODO CHANGE, REMOVE
            {
                Console.WriteLine("write when shouldnt: {0}",message);
            } else
            {
                this.telnetClient.write(message);
            }
        }
        #endregion





    }
}
