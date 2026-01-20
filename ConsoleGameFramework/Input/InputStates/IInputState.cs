namespace ConsoleGameFramework.Input.InputStates;

public interface IInputState
{
    InputHandleResult? HandleInput(ConsoleKeyInfo keyInfo);
}