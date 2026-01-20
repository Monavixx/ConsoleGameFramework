using ConsoleGameFramework.Commands.Menu;
using ConsoleGameFramework.Screens.Menu;

namespace ConsoleGameFramework.Input.InputStates;

public class BaseMenuInputState : InputState
{
    public BaseMenuInputState(IMenuContext menuContext)
    {
        RegisterCommand(ConsoleKey.DownArrow, () => new NextMenuOptionCommand(menuContext));
        RegisterCommand(ConsoleKey.UpArrow, () => new PreviosMenuOptionCommand(menuContext));
        RegisterCommand(ConsoleKey.Enter, () => new ExecuteSelectedMenuOptionCommand(menuContext));
    }
}