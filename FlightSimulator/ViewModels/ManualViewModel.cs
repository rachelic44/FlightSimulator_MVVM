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
                Console.WriteLine("fffvbt");
                //TO DO!!!
                //tell the model to send to the simulator (this is the other side, so have to declere oneWayToSource
            }
        }
    }
}
