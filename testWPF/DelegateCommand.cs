using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace testWPF
{
    class DelegateCommand : ICommand
    {
        public DelegateCommand(Action<object> executeAction): this(executeAction, null)
        {

        }
        public DelegateCommand(Action<object> executeAction, Func<object, bool> canExecuteFunc)
        {
            execute = executeAction;
            canExecute = canExecuteFunc;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
        Action<object> execute;
        Func<object, bool> canExecute;

        public bool CanExecute(object parameter)
        {
            if (canExecute != null) return canExecute(parameter);
            return true;
        }

        public void Execute(object parameter)
        {
            execute?.Invoke(parameter);
        }
    }
}
