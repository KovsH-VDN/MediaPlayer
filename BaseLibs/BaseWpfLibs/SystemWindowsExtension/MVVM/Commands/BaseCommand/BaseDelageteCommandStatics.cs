using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SystemExtension.MVVM.Commands
{
    public abstract partial class BaseDelegateCommand : BaseCommand, ICommand
    {
        public static ICommand Create(Action action) => new DelegateCommand(action);
        public static ICommand Create(Action action, Func<object, bool> canExecute) => new DelegateCommand(action, canExecute);
        public static ICommand Create(Action<object> executeWithParameter) => new DelegateCommandWithParameter(executeWithParameter);
        public static ICommand Create(Action<object> executeWithParameter, Func<object, bool> canExecute) => new DelegateCommandWithParameter(executeWithParameter, canExecute);
    }
}