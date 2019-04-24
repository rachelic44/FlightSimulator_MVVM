using FlightSimulator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlightSimulator.ViewModels
{
    public class AutoPilotViewModel : BaseNotify
    {
        private AutoPilotModel model;
        private string autoPilotData;
        public AutoPilotViewModel (AutoPilotModel model)
        {
            this.model = model;
            this.autoPilotData = "";
        }


        public string AutoPilotData
        {
            get { return this.autoPilotData; }
            
            set
            {
                this.autoPilotData = value;
             //   NotifyPropertyChanged("AutoPilotData");
            }
        }


        #region Commands
        #region ClearCommand
        private ICommand _ClearCommand;
        public ICommand ClearCommand
        {
            get
            {
                return _ClearCommand ?? (_ClearCommand = new CommandHandler(() => OnClear()));
            }
        }
        private void OnClear()
        {
            Console.WriteLine("yayyy");
            this.AutoPilotData = "";
            NotifyPropertyChanged("AutoPilotData"); //in set../
        }
        #endregion

        #region OkCommand
        private ICommand _OkCommand;
        public ICommand OkCommand
        {
            get
            {
               
                return _OkCommand ?? (_OkCommand = new CommandHandler(() => OnOk()));
            }
        }
        private void OnOk()
        {
            Console.WriteLine("dfsdfsfdsf");
            // model.ReloadSettings();
            if (AutoPilotData != "")
            {
                Console.WriteLine("send it");
                string[] result = AutoPilotData.Split('\n');
                foreach(string line in result) {
                    Connection.Instance.TelnetClient.write(line+"\r\n");
                }
                this.AutoPilotData = ""; //and not set..
            }
        }
        #endregion
        #endregion
    }
}
