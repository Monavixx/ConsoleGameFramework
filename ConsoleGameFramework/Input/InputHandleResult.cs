using ConsoleGameFramework.Screens;

namespace ConsoleGameFramework.Input;

public sealed record InputHandleResult(InputActionType Action, Type? TargetScreenType = null)
{
    public static InputHandleResult NavigateTo<TScreen>() where TScreen : Screen
    {
        return new InputHandleResult(InputActionType.NavigateTo, typeof(TScreen));
    }

    public static InputHandleResult Exit() => new InputHandleResult(InputActionType.Exit);
    public static InputHandleResult None() => new InputHandleResult(InputActionType.None);
}