using System.Diagnostics.CodeAnalysis;
using ConsoleGameFramework.Input;
using ConsoleGameFramework.Input.InputStates;
using ConsoleGameFramework.Viewport;

namespace ConsoleGameFramework.Screens;

public abstract class Screen : IScreen, IScreenContext
{
    private InputState? _inputState = null;

    public void SetInputState(InputState inputState)
    {
        _inputState = inputState;
    }

    public abstract void Render();
    public InputHandleResult? HandleInput(ConsoleKeyInfo keyInfo)
    {
        return _inputState?.HandleInput(keyInfo);
    }

    [SetsRequiredMembers]
    protected Screen(IViewport viewport)
    {
        Viewport = viewport;
    }

    public required IViewport Viewport { get; init; }
    public virtual void Update(TimeSpan deltaTime) { }

    public virtual void Dispose()
    {
    }
}