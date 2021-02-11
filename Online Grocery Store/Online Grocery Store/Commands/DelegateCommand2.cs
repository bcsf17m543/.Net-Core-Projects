using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace Online_Grocery_Store.Commands
{
    class DelegateCommand2 : ICommand
    {
        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }

        }
       
        private Action<object> _execute;
        private Predicate<object> _canExecute;
        public DelegateCommand2(Action<object> e, Predicate<object> c)
        {
            this._execute = e;
            this._canExecute = c;
        }
        public bool CanExecute(object parameter)
        {

            return this._canExecute(parameter as string);
        }

        public void Execute(object parameter)
        {
            this._execute(parameter as string);
        }
    }
}
