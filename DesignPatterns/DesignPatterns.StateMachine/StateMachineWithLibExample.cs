using DesignPatterns.Common.Interfaces;
using DesignPatterns.StateMachine.Sates;
using DesignPatterns.StateMachine.Triggers;
using Stateless;

namespace DesignPatterns.StateMachine
{
    public class StateMachineWithLibExample : ILauncher
    {
        private static readonly string _line = "=========================================================";
        public void Run()
        {
            var configuration = ConfigureStateMachine();

            // List with all Triggers
            var allTriggers = Enum.GetValues(typeof(TriggerPhone))
                .Cast<TriggerPhone>();

            while (configuration.PermittedTriggers.Count() != 0)
            {
                Dump($"PermittedTriggers: {configuration.PermittedTriggers.Count()}");
                Dump("---- What can you do next ----");

                foreach (var item in configuration.PermittedTriggers)
                {
                    // Display all available options for current state
                    Dump($"{(int)item} - {item}");
                }

                int.TryParse(Console.ReadLine(), out int input);

                TriggerPhone next = (TriggerPhone)input;

                configuration.Fire(next);
            }
        }

        private StateMachine<PhoneState, TriggerPhone> ConfigureStateMachine()
        {
            var rules = new StateMachine<PhoneState, TriggerPhone>(PhoneState.OffHook);

            rules.Configure(PhoneState.OffHook)
                .Permit(TriggerPhone.CallDialed, PhoneState.Connecting)
                .OnEntry(() => WriteState(rules))
                .OnExit(() => Exit(PhoneState.OffHook, ConsoleColor.DarkRed));

            rules.Configure(PhoneState.Connecting)
                .Permit(TriggerPhone.PlacedOnHook, PhoneState.OffHook)
                .Permit(TriggerPhone.CallConnected, PhoneState.Connected)
                .OnEntry(() => WriteState(rules))
                .OnExit(() => Exit(PhoneState.Connecting, ConsoleColor.DarkRed));

            rules.Configure(PhoneState.Connected)
                // 'PermitReentry' assume that you [are able] to get back to the state you're in
                .PermitReentry(TriggerPhone.LeftMessage)
                // 'Permit' assume that you [are not able] to get back to the state you're in
                .Permit(TriggerPhone.PlacedOnHook, PhoneState.OffHook)
                .Permit(TriggerPhone.TakenOffhold, PhoneState.OnHook)
                .Permit(TriggerPhone.EndThis, PhoneState.EndThis)
                .OnEntry(() => WriteState(rules))
                .OnExit(() => Exit(PhoneState.Connected, ConsoleColor.DarkRed));

            rules.Configure(PhoneState.EndThis);

            return rules;
        }

        private void Exit(PhoneState state, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Dump($"{_line}\n[EXIT] Old state [{state}]!");
            Console.ResetColor();
        }

        private void WriteState(StateMachine<PhoneState, TriggerPhone> state)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"[WRITE STATE] Current state [{state.State}]\n{_line}");
            Console.ResetColor();
        }

        private void Dump(string v)
            => Console.WriteLine(v);
    }
}
