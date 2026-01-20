using ConsoleGameFramework.Screens;
using ConsoleGameFramework.Viewport;

namespace ConsoleGameFramework;

public class AppNavigator
{
    public required ScreenFactory ScreenFactory { get; init; }
    public required IViewport Viewport { get; init; }
    public required IScreen CurrentScreen
    {
        get;
        set
        {
            field?.Dispose();
            field = value;
        }
    }

    public void NavigateTo(Type screenType)
    {
        CurrentScreen = ScreenFactory.Create(screenType, Viewport);
    }
}