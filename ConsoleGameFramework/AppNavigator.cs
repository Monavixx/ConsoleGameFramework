using ConsoleGameFramework.Screens;
using ConsoleGameFramework.Viewport;

namespace ConsoleGameFramework;

public class AppNavigator
{
    public required ScreenFactory ScreenFactory { get; init; }
    public required IViewport Viewport { get; init; }

    public IScreen CurrentScreen
    {
        get;
        set
        {
            field?.Dispose();
            field = value;
        }
    } = null!;

    public void NavigateTo(Type screenType)
    {
        CurrentScreen = ScreenFactory.Create(screenType, Viewport);
    }
}