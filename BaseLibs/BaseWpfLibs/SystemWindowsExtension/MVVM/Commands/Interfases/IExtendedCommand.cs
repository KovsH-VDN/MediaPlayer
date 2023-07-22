using System.Windows.Input;

namespace SystemExtension.MVVM.Commands
{
    public interface IExtendedCommand : ICommand
    {
        void Undo();
        void Redo();
    }
}
