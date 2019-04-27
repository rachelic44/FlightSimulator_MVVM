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
                Console.WriteLine("vm n");
                /* let the observers of the vie model the model) know that a property changed */
                 NotifyPropertyChanged(e.PropertyName);// - kind of reaction, dont have to. can do other stuff here
                // NotifyPropertyChanged("VM_" + e.PropertyName);
                //Console.WriteLine("/./");
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
            Console.WriteLine("on connect func");
             flightBoardModel.OpenConnections();

           

              /* ITelnetClient tclient = new MyTelnetClient();
               ISimulatorModel sm = new SimulatorModel(tclient);
               sm.connectAsClient("127.0.0.1", 5402);
               sm.startClient();
               Console.WriteLine("5\n\n");*/
        }
    }
}
