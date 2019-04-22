using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using FlightSimulator.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlightSimulator.ViewModels
{
    public class FlightBoardViewModel : BaseNotify
    {
        private FlightBoardModel flightBoardModel;

        public FlightBoardViewModel(FlightBoardModel model)
        {
            this.flightBoardModel = model;
            
        }

        public double Lon
        {
            get;
        }

        public double Lat
        {
            get;
        }


        private ICommand openSettings;
        public ICommand OpenSettings
        {
            get
            {
                 return openSettings ?? (openSettings = new CommandHandler(() => OnClickSettings()));
            }
        }
        private void OnClickSettings()
        {
            Settings setting = new Settings();
            setting.ShowDialog();
        }


        private ICommand connectCommand;
        public ICommand ConnectCommand
        {
            get
            {
                return connectCommand ?? (connectCommand = new CommandHandler(() => OnClickConnect()));
            }
        }
        private void OnClickConnect()
        {
          
        }
    }
}
