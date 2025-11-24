
namespace VendingMachineApp.Domain.Entities
{
    public class TransitionResult
    {
        public string MessageOutput { get; set; } = string.Empty;

        public States NewState { get; set; }

        public bool TransitionSuccess { get; set; }

        public TransitionResult(States newState, bool transitionSuccess, string messageOutput)
        {
            NewState = newState;
            TransitionSuccess = transitionSuccess;
            MessageOutput = messageOutput;
        }
    }
}
