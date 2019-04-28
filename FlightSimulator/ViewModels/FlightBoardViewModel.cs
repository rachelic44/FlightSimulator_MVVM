using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using FlightSimulator.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Sockets;
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
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                /* let the observers of the vie model the model) know that a property changed */
                 NotifyPropertyChanged(e.PropertyName);
            };
        }

        public double? Lon
        {
            get { return flightBoardModel.Lon; }
           
        }

        public double? Lat
        {
            get { return flightBoardModel.Lat; }
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
            flightBoardModel.OpenConnections();
        }

        private ICommand disconnectCommand;
        public ICommand DisConnectCommand
        {
            get
            {
                return disconnectCommand ?? (disconnectCommand = new CommandHandler(() => DisConnection()));
            }
        }

        private void DisConnection()
        {
            flightBoardModel.CloseConnections();
        }
       
    }
}
