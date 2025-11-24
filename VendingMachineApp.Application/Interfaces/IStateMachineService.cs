using VendingMachineApp.Domain.Entities;

namespace VendingMachineApp.Application.Interfaces
{
    public interface IStateMachineService
    {

        /// <summary>
        /// Current state of the vending machine
        /// </summary>
        States CurrentState { get; }

        /// <summary>
        /// Process an entry and perform state transition
        /// </summary>
        TransitionResult ProcessEntry(Entrys entry);

        /// <summary>
        /// Reset the state machine to the initial state
        /// </summary>
        void Reset();

    }
}
