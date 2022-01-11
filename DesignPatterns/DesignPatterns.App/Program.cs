using DesignPatterns.App.Enums;
using DesignPatterns.State;
using DesignPatterns.StateMachine;
using DesignPatterns.Strategy;
using System;
using System.Collections.Generic;

namespace DesignPatterns.App
{
    class Program
    {
        private static readonly string _line = "=========================================================";
        private static readonly Dictionary<PatternTypes, Action> _designPatterns = new()
        {
            { PatternTypes.State, () => ExecuteExampleStatePattern() },
            { PatternTypes.Strategy, () => ExecuteExampleStrategyPattern() },
            { PatternTypes.StateMachine, () => ExecuteStateMachinePattern() },
            { PatternTypes.StateMachineWithAction, () => ExecuteStateMachineWithActionPattern() },
            { PatternTypes.StateMachineWithLibExample, () => ExecuteStateMachineWithLibExample() }
        };

        static void Main(string[] args)
        {
            foreach (var item in _designPatterns)
            {
                Console.WriteLine($"Do you want skip pattern [{item.Key}]? y/N");
                if (Console.ReadLine() == "y") continue; 

                _designPatterns[item.Key].Invoke();
            }

            Console.ReadLine();
        }

        private static void ExecuteExampleStatePattern()
        {
            DisplayHeader(PatternTypes.State);
            StateExample stateExample = new();
            stateExample.Run();
            Console.WriteLine($"{_line}\n");
        }

        private static void ExecuteExampleStrategyPattern()
        {
            DisplayHeader(PatternTypes.Strategy);
            StrategyExample strategyExample = new();
            strategyExample.Run();
            Console.WriteLine($"{_line}\n");
        }

        private static void ExecuteStateMachinePattern()
        {
            DisplayHeader(PatternTypes.StateMachine);
            StateMachineExample stateMachineExample = new();
            stateMachineExample.Run();
            Console.WriteLine($"{_line}\n");
        }

        private static void ExecuteStateMachineWithActionPattern()
        {
            DisplayHeader(PatternTypes.StateMachineWithAction);
            StateMachineWithActionExample stateMachineWithActionExample = new();
            stateMachineWithActionExample.Run();
            Console.WriteLine($"{_line}\n");
        }

        private static void ExecuteStateMachineWithLibExample()
        {
            DisplayHeader(PatternTypes.StateMachineWithLibExample);
            StateMachineWithLibExample stateMachineWithLibExample = new();
            stateMachineWithLibExample.Run();
            Console.WriteLine($"{_line}\n");
        }

        private static void DisplayHeader(PatternTypes type)
        {
            Console.WriteLine($"{_line}\n{type} Pattern\n{_line}");
        }
    }
}
