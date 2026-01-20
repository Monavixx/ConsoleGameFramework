using ConsoleGameFramework.Input;
using ConsoleGameFramework.Screens.Menu;

namespace ConsoleGameFramework.Commands.Menu;

public class ExecuteSelectedMenuOptionCommand (IMenuContext menuContext): ICommand
{
    public InputHandleResult? Execute()
    {
        return menuContext.ExecuteSelected();
    }
}