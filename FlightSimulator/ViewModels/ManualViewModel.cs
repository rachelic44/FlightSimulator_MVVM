using FlightSimulator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.ViewModels
{
    class ManualViewModel
    {
        private ManualModel model;
        private string throttlePath = "/controls/engines/current-engine/throttle";
        private string rudderPath = "/controls/flight/rudder";
        private string elevatorPath = "/controls/flight/elevator";
        private string aileronPath = "/controls/flight/aileron";
        public ManualViewModel(ManualModel model)
        {
            this.model = model;
        }

        private double? aileron;
        public double? Aileron
        {
            get { return this.aileron; }
            set
            {
                this.aileron = value;
                //tell the model to send to the simulator (this is the other side, so have to declere oneWayToSource
                model.sendMessage("set " + aileronPath + " " + Convert.ToString(value));
            }
        }
        private double? elevator;
        public double? Elevator
        {
            get { return this.elevator; }
            set
            {
                this.elevator = value;
                //tell the model to send to the simulator (this is the other side, so have to declere oneWayToSource
                model.sendMessage("set " + elevatorPath + " " + Convert.ToString(value));
              
            }
        }
        private double? throttle;
        public double? Throttle
        {
            get { return this.throttle; }
            set
            {
                this.throttle = value;
                //tell the model to send to the simulator (this is the other side, so have to declere oneWayToSource
                model.sendMessage("set " + throttlePath + " " + Convert.ToString(value));

            }
        }
        private double? rudder;
        public double? Rudder
        {
            get { return this.rudder; }
            set
            {
                this.rudder = value;
                Console.WriteLine("rudder");
                //tell the model to send to the simulator (this is the other side, so have to declere oneWayToSource
                model.sendMessage("set " + rudderPath + " " + Convert.ToString(value));

            }
        }
    }
}
