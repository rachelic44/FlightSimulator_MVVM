using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FlightSimulator.Model
{
    class CommandHandlerWArg : ICommand
    {

        public delegate void Action2(Window w);

        private Action2 _action;

        public CommandHandlerWArg(Action2 action)
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
            Console.WriteLine("P");
           
            _action(parameter as Window);
        }

    }
}
