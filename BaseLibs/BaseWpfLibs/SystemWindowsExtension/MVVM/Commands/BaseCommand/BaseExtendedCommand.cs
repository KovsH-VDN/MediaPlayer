using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemExtension.MVVM.Commands
{
    public abstract class BaseExtendedCommand : BaseCommand, IExtendedCommand
    {
        protected IExtendedCommandManager ExtendedCommandManager { get; }
        protected object Parameter { get; set; }
        protected BaseExtendedCommand(IExtendedCommandManager extendedCommandManager) => ExtendedCommandManager = extendedCommandManager ?? throw new ArgumentNullException(nameof(extendedCommandManager));

        public override void Execute(object parameter)
        {
            Parameter = parameter;
            Execute();
        }
        protected void AddToManager() => ExtendedCommandManager.AddCommand(this);

        public abstract void Execute();
        public abstract void Undo();
        public abstract void Redo();
    }
}
