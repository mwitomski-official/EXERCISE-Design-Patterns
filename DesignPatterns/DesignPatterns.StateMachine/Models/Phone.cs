using DesignPatterns.StateMachine.Sates;
using DesignPatterns.StateMachine.Triggers;

namespace DesignPatterns.StateMachine.Models
{
    public class Phone
    {
        public TriggerPhone TriggerPhone { get; set; }
        public PhoneState PhoneState { get; set; }

        public Phone(TriggerPhone triggerPhone, PhoneState phoneSate)
        {
            TriggerPhone = triggerPhone;
            PhoneState = phoneSate;
        }
    }
}
