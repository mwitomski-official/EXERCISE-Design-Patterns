using DesignPatterns.Common.Interfaces;
using DesignPatterns.StateMachine.Models;
using DesignPatterns.StateMachine.Sates;

namespace DesignPatterns.StateMachine
{
    public class StateMachineExample : ILauncher
    {
        private readonly Dictionary<PhoneState, List<Phone>> rules = new()
        {
            [PhoneState.OffHook] = new List<Phone>
            {
                new Phone(Triggers.TriggerPhone.CallDialed, PhoneState.Connecting)
            },
            [PhoneState.Connecting] = new List<Phone>
            {
                new Phone(Triggers.TriggerPhone.HangUp, PhoneState.OffHook),
                new Phone(Triggers.TriggerPhone.CallConnected, PhoneState.Connected)
            },
            [PhoneState.Connected] = new List<Phone>
            {
                new Phone(Triggers.TriggerPhone.HangUp, PhoneState.OffHook),
                new Phone(Triggers.TriggerPhone.LeftMessage, PhoneState.Connected),
                new Phone(Triggers.TriggerPhone.EndThis, PhoneState.EndThis)
            },
            [PhoneState.EndThis] = new List<Phone>
            {

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

                for(var i =0; i< rules[phoneState].Count; i++)
                {
                    var phone = rules[phoneState][i];
                    Dump($"{i}. {phone.PhoneState}");
                }

                int input = int.Parse(s: Console.ReadLine() ?? "0");
                var newPhone = rules[phoneState][input];
                phoneState = newPhone.PhoneState;

            } while (rules[phoneState].Count != 0);
        }

        private void Dump(string v)
            => Console.WriteLine(v);
    }
}
