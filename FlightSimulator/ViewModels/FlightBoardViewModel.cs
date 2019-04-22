using FlightSimulator.Model;
using FlightSimulator.Model.Interface;
using FlightSimulator.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
            model.PropertyChanged += delegate (Object sender, PropertyChangedEventArgs e)
            {
                // NotifyPropertyChanged("VM_" + e.PropertyName); };// - kind of reaction, dont have to. cat do other stuff here
                Console.WriteLine("in pr");
            };
        }

        public double Lon
        {
            get;
            set;
        }

        public double Lat
        {
            get;
            set;
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
