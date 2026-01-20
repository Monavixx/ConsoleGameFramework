using ConsoleGameFramework.Input;
using ConsoleGameFramework.Screens.Menu;

namespace ConsoleGameFramework.Commands.Menu;

public class NextMenuOptionCommand (IMenuContext menuContext) : ICommand
{
    public InputHandleResult? Execute()
    {
        ++menuContext.SelectedIndex;
        return InputHandleResult.None();
    }
}