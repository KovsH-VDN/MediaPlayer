using System;

namespace SystemExtension.MVVM.Commands
{
    public class DelegateCommandWithParameter : BaseDelegateCommand
    {
        private Action<object> _execute;

        public DelegateCommandWithParameter(Action<object> execute) : base() => _execute = execute;
        public DelegateCommandWithParameter(Action<object> execute, Func<object, bool> canExecute) : this(execute) => _canExecute = canExecute;

        public override void Execute(object parameter) => _execute?.Invoke(parameter);
    }
}