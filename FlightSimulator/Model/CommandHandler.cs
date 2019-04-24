using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlightSimulator.Model
{
    public class CommandHandler : ICommand
    {
        private Action _action;
        public CommandHandler(Action action)
        {
            _action = action;
        }

        public bool CanExecute(object parameter)
        {
            //when changes for true, let all the listeners know that can execute - automatically will(t)
           // CanExecuteChanged(this,);
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            
            _action();
        }
    }
}
