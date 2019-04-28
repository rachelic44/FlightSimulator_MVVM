using FlightSimulator.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace FlightSimulator.ViewModels
{
    public class AutoPilotViewModel : BaseNotify
    {
        private AutoPilotModel model;
        private string autoPilotData;
        private string backColor;

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
                if(value=="") {
                    BackColor = "White";
                } else {
                    BackColor = "LightPink";
                }
             //   NotifyPropertyChanged("AutoPilotData"); m down
            }
        }

        public string BackColor
        {
            get { return this.backColor; }
            set {
                this.backColor = value;
                NotifyPropertyChanged("BackColor");}

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
                /*  Console.WriteLine("send it");  //TODO CLEAR IT, TRANSFARED TO THR MODEL
                  string[] result = AutoPilotData.Split('\n');
                  foreach(string line in result) {
                      if (line == "\r\n" || line == "\r" || line == "\n") { continue; };
                      Connection.Instance.TelnetClient.write(line+"\r\n");
                  }*/
                this.model.writeMessages(AutoPilotData);
                this.AutoPilotData = ""; //without deleting (only on clear)
                Console.WriteLine("g sec 2 2 2  ");
            }
        }
        #endregion
        #endregion
    }
}
