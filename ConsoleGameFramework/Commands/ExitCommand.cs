using ConsoleGameFramework.Input;

namespace ConsoleGameFramework.Commands;

public class ExitCommand : ICommand
{
    public InputHandleResult? Execute()
    {
        return InputHandleResult.Exit();
    }
}