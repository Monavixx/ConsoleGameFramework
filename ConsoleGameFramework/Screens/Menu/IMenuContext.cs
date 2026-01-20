using ConsoleGameFramework.Input;

namespace ConsoleGameFramework.Screens.Menu;

public interface IMenuContext : IScreenContext
{
    int SelectedIndex { get; set; }
    List<string> OptionLabels { get; }
    InputHandleResult? ExecuteSelected();
}