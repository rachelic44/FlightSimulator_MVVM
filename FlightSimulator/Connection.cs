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

        private MyTelnetClient telnetClient;
        private bool gotClient = false;
        public bool GotClient
        {
            get { return this.gotClient;  }
            set { this.gotClient = value; }
        }
        private bool stopReading = false;
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

        public void setClient(MyTelnetClient telnetClient)
        {
            this.telnetClient = telnetClient;
        }
        #endregion

      
  

        
    }
}
