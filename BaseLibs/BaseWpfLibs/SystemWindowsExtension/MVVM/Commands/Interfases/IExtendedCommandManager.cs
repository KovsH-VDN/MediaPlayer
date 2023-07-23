using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SystemExtension.MVVM.Commands
{
    public interface IExtendedCommandManager
    {
        Func<bool> CanUndoRedoExecute { get; set; }
        ICommand UndoCommand { get; }
        ICommand RedoCommand { get; }
        void AddCommand(IExtendedCommand command);
    }
}
