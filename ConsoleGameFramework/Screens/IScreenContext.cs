using ConsoleGameFramework.Viewport;

namespace ConsoleGameFramework.Screens;

public interface IScreenContext
{
    IViewport Viewport { get; }
}