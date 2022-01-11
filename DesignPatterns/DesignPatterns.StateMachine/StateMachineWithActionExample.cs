using DesignPatterns.Common.Interfaces;
using DesignPatterns.StateMachine.Controllers;
using DesignPatterns.StateMachine.Models;
using DesignPatterns.StateMachine.Sates;

namespace DesignPatterns.StateMachine
{
    public class StateMachineWithActionExample : ILauncher
    {
        private readonly Dictionary<PhoneState, StateController> rules = new()
        {
            [PhoneState.OffHook] = new StateController()
            {
                PermittedStatesAndTriggers = new()
                {
                    new(triggerPhone: Triggers.TriggerPhone.CallDialed,
                        phoneSate: PhoneState.Connecting)
                },
                OnEntryAction = DoAction1
            },
            [PhoneState.Connecting] = new StateController()
            {
                PermittedStatesAndTriggers = new()
                {
                    new(triggerPhone: Triggers.TriggerPhone.HangUp,
                        phoneSate: PhoneState.OffHook),
                    new(triggerPhone: Triggers.TriggerPhone.CallConnected,
                        phoneSate: PhoneState.Connected)
                },
                OnEntryAction = DoAction2
            },
            [PhoneState.Connected] = new StateController()
            {
                PermittedStatesAndTriggers = new()
                {
                    new(triggerPhone: Triggers.TriggerPhone.HangUp,
                        phoneSate: PhoneState.OffHook),
                    new(triggerPhone: Triggers.TriggerPhone.LeftMessage,
                        phoneSate: PhoneState.Connected),
                    new(triggerPhone: Triggers.TriggerPhone.EndThis,
                        phoneSate: PhoneState.EndThis)
                },
                OnEntryAction = DoAction1
            },
            [PhoneState.EndThis] = new StateController()
            {
                PermittedStatesAndTriggers = new()
            }
        };

        public void Run()
        {
            PhoneState phoneState = PhoneState.OffHook;

            do
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Dump($"Current state: {phoneState}");
                Console.ResetColor();

                Dump($"Select a trigger");

                for (var i = 0; i < rules[phoneState].PermittedStatesAndTriggers?.Count; i++)
                {
                    var currentPhone = rules[phoneState].PermittedStatesAndTriggers?[i];

                    Console.WriteLine($"{i}. {currentPhone?.TriggerPhone}");
                }

                rules[phoneState]?.OnEntryAction();

                var userInput = int.Parse(Console.ReadLine() ?? "0");
                var phone = rules[phoneState].PermittedStatesAndTriggers?[userInput];
                phoneState = phone.PhoneState;

            } while (rules[phoneState].PermittedStatesAndTriggers?.Count != 0);

        }

        #region Actions
        private static void DoAction1()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Dump("###ACTION1");
            Console.ResetColor();
        }
        private static void DoAction2()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Dump("###ACTION2");
            Console.ResetColor();
        }
        #endregion

        private static void Dump(string v)
            => Console.WriteLine(v);
    }
}
