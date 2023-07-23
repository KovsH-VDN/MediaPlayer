using System;
using System.Collections.Generic;
using System.Windows.Input;

namespace SystemExtension.MVVM.Commands
{
    public class ExtendedCommandManager : IExtendedCommandManager
    {
        private LinkedList<IExtendedCommand> UndoCommands { get; }
        private LinkedList<IExtendedCommand> RedoCommands { get; }

        public int CommandsCountRestriction { get; private set; }
        public ICommand UndoCommand { get; private set; }
        public ICommand RedoCommand { get; private set; }
        public Func<bool> CanUndoRedoExecute { get; set; } = () => true;

        public bool Undoing { get; private set; }
        public bool Redoing { get; private set; }

        public ExtendedCommandManager()
        {
            UndoCommands = new LinkedList<IExtendedCommand>();
            RedoCommands = new LinkedList<IExtendedCommand>();

            UndoCommand = new DelegateCommand(Undo, p => UndoCommands.Count != 0);
            RedoCommand = new DelegateCommand(Redo, p => RedoCommands.Count != 0);
        }
        public ExtendedCommandManager(int commandsCountRestriction) : this() => CommandsCountRestriction = commandsCountRestriction;

        public void AddCommand(IExtendedCommand command)
        {
            RedoCommands.Clear();
            Push(UndoCommands, command);
        }

        private void Undo()
        {
            if (UndoCommands.Count == 0)
                return;
            Undoing = true;
            IExtendedCommand command = Pop(UndoCommands);
            command.Undo();

            Push(RedoCommands, command);
            Undoing = false;
        }
        private void Redo()
        {
            if (RedoCommands.Count == 0)
                return;
            Redoing = true;
            IExtendedCommand command = Pop(RedoCommands);
            command.Redo();

            Push(UndoCommands, command);
            Redoing = false;
        }
        private void Push(LinkedList<IExtendedCommand> commands, IExtendedCommand command)
        {
            commands.AddLast(command);
            CheckCollectionLimit(commands);
        }
        private IExtendedCommand Pop(LinkedList<IExtendedCommand> commands)
        {
            IExtendedCommand command = commands.Last.Value;
            commands.RemoveLast();

            return command;
        }
        private void CheckCollectionLimit(LinkedList<IExtendedCommand> commands)
        {
            if (0 < CommandsCountRestriction && commands.Count > CommandsCountRestriction)
                commands.RemoveFirst();
        }
    }
}
