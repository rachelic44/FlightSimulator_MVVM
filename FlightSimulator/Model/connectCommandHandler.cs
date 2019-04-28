using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlightSimulator.Model
{
    public class ConnectCommandHandler : ICommand
    {
        private Action _action;
        public ConnectCommandHandler(Action action)
        {
            _action = action;
        }

        public bool CanExecute(object parameter)
        {
            if(Connection.Instance.SimulatorOpened)
            {
                CanExecuteChanged?.Invoke(this, new PropertyChangedEventArgs("CanExecute"));
                return true;
            }
            return false;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {

            _action();
        }
    }
}
