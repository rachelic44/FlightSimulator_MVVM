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
        }


        public string AutoPilotData
        {
            get { return this.autoPilotData;
            }
            set
            {
                this.autoPilotData = value;
                NotifyPropertyChanged("AutoPilotData");
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
            this.AutoPilotData = String.Empty;
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
        }
        #endregion
        #endregion
    }
}
