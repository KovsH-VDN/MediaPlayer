using System;

namespace SystemExtension.MVVM.Commands
{
    public class DelegateCommand : BaseDelegateCommand
    {
        private readonly Action _execute;

        public DelegateCommand(Action execute) : base() => _execute = execute;
        public DelegateCommand(Action execute, Func<object, bool> canExecute) : this(execute) => _canExecute = canExecute;

        public override void Execute(object parameter) => _execute?.Invoke();
    }
}