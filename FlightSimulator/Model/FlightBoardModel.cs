using FlightSimulator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlightSimulator.Model
{
    public class FlightBoardModel : BaseNotify
    {
        private double lat;
        private double lon;

        public double Lat
        {
            get { return this.lat; }
            set
            {
                this.lat = value;
                NotifyPropertyChanged("Lat");
            }
        }

        // property Lon
        public double Lon
        {
            get { return this.lon; }
            set
            {
                this.lon = value;
                NotifyPropertyChanged("Lon");
            }
        }
    }
}
