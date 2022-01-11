using DesignPatterns.StateMachine.Models;

namespace DesignPatterns.StateMachine.Controllers
{
    public class StateController
    {
        public List<Phone>? PermittedStatesAndTriggers { get; set; }
        public Action? OnEntryAction { get; set; }

        public void CallAction()
         => OnEntryAction?.Invoke();
    }
}
