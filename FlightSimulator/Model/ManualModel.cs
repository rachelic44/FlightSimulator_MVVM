using FlightSimulator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    class ManualModel : BaseNotify
    {
        private double rudder;
        private double throttle;
        private double aileron;
        private double elevator;
        public double Rudder
        {
            set { this.rudder = value; }
        }

        public double Throttle
        {
            set { this.throttle = value; }
        }

        public double Aileron
        {
            set { this.aileron = value; }
        }

        public double Elevator
        {
            set { this.elevator = value; }
        }
        public void sendMessage(string message)
        {
            /* Send the client the message to write to the simuator */
            Connection.Instance.AskClientToWrite(message+"\r\n");
        }
    }
}
