using System.Diagnostics;
using ConsoleGameFramework.Input;
using ConsoleGameFramework.Screens;
using ConsoleGameFramework.Viewport;

namespace ConsoleGameFramework;

public class Application
{
    private readonly AppNavigator _navigator;
    public GlobalInputManager GlobalInputManager { get; set; }
    private readonly IViewport _viewport;
    private readonly ScreenFactory _screenFactory;

    public bool IsRunning { get; private set; } = false;

    public Application(IViewport viewport)
    {
        _viewport = new ConsoleViewport();
        _screenFactory = new ScreenFactory();
        _navigator = new AppNavigator()
        {
            ScreenFactory = _screenFactory,
            Viewport = _viewport,
        };
        GlobalInputManager = new GlobalInputManager();
    }

    public Application RegisterScreens(Action<ScreenFactory> action)
    {
        action(_screenFactory);
        return this;
    }

    public Application CurrentScreen<TScreen>() where TScreen : IScreen
    {
        _navigator.NavigateTo(typeof(TScreen));
        return this;
    }
    
    public void Run()
    {
        try
        {
            IsRunning = true;
            Console.CursorVisible = false;
            var stopWatch = Stopwatch.StartNew();
            var lastTick = stopWatch.Elapsed;
            
            while (IsRunning)
            {
                var now = stopWatch.Elapsed;
                var delta = now - lastTick;
                lastTick = now;
                
                _viewport.Update();

                _navigator.CurrentScreen.Update(delta);
                _navigator.CurrentScreen.Render();
                
                if (Console.KeyAvailable)
                {
                    var key = Console.ReadKey(true);
                    var inputHandleResult = _navigator.CurrentScreen.HandleInput(key)
                                            ?? GlobalInputManager.HandleInput(key);
                    if (inputHandleResult != null)
                        switch (inputHandleResult.Action)
                        {
                            case InputActionType.Exit:
                                IsRunning = false;
                                break;
                            case InputActionType.NavigateTo:
                                _navigator.NavigateTo(inputHandleResult.TargetScreenType!);
                                break;
                        }
                }
            }

            // Final render
            _navigator.CurrentScreen.Render();
        }
        finally
        {
            Console.CursorVisible = true;
            Console.ResetColor();
            IsRunning = false;
        }
    }
}