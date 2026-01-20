using ConsoleGameFramework.Input;
using ConsoleGameFramework.Viewport;

namespace ConsoleGameFramework.Screens;

public interface IScreen : IDisposable
{
    void Render();
    InputHandleResult? HandleInput(ConsoleKeyInfo key);
    IViewport Viewport { get; }
    void Update(TimeSpan deltaTime);
}