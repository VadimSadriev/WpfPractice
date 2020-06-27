using System;
using System.Windows.Input;

namespace WpfPractice.Commands
{
    public class RelayParamCommand : ICommand
    {
        private readonly Action<object> _action;

        public event EventHandler CanExecuteChanged = (sender, e) => { };

        public RelayParamCommand(Action<object> action)
        {
            _action = action;
        }

        public bool CanExecute(object parameter) => true;

        public void Execute(object parameter)
        {
            _action(parameter);
        }
    }
}
