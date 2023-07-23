using System;
using System.Windows.Input;

namespace SystemExtension.MVVM.Commands
{
    public abstract partial class BaseDelegateCommand : BaseCommand, ICommand
    {
        protected Func<object, bool> _canExecute;

        protected BaseDelegateCommand() => _canExecute = (parameter) => true;

        public override bool CanExecute(object parameter) => _canExecute(parameter);
    }
}