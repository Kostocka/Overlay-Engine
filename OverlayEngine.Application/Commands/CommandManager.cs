namespace OverlayEngine.Application.Commands;

public sealed class CommandManager
{
    private readonly Stack<ICommand> _undo = new();
    private readonly Stack<ICommand> _redo = new();

    public void Execute(ICommand command)
    {
        command.Execute();

        _undo.Push(command);

        _redo.Clear();
    }

    public void Undo()
    {
        if (_undo.Count == 0)
            return;

        var command = _undo.Pop();

        command.Undo();

        _redo.Push(command);
    }

    public void Redo()
    {
        if (_redo.Count == 0)
            return;

        var command = _redo.Pop();

        command.Execute();

        _undo.Push(command);
    }
}