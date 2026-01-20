using ConsoleGameFramework.Input;

namespace ConsoleGameFramework.Commands;

public interface ICommand
{
    InputHandleResult? Execute();
}