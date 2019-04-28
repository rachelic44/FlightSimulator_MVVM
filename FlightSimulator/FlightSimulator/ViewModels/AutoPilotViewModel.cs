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

        /* property AutoPilotData, binded to the xaml */
        public string AutoPilotData
        {
            get { return this.autoPilotData; }
            
            /* set without notifying, so only "clear" method will notify to delete the string */
            set
            {
                this.autoPilotData = value;
                if(value=="") {
                    BackColor = "White";
                } else {
                    BackColor = "LightPink";
                }
            }
        }

        /* back color, binded to the code behind, so each change will change the back color, based on Convertor  */
        public string BackColor
        {
            get { return this.backColor; }
            set {
                this.backColor = value;
                NotifyPropertyChanged("BackColor");}
        }


        #region Commands
        /*ClearCommand - to clear the text and change the color accodingly */
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
            /* delete the text and notify the xaml that the text property has changed  */
            this.AutoPilotData = "";
            NotifyPropertyChanged("AutoPilotData"); 
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
            if (AutoPilotData != "")
            {
                this.model.writeMessages(AutoPilotData);
                /* change the string without notifying on the color changed */ 
                this.AutoPilotData = ""; 
            }
        }
        #endregion
        #endregion
    }
}
