using VendingMachineApp.Application.Interfaces;
using VendingMachineApp.Domain.Entities;

namespace VendingMachineApp.Infraestructure.Service
{
    public class StateMachineService : IStateMachineService
    {
        private readonly StateMachine _machine = new();

        public States CurrentState => _machine.CurrentState;

        public TransitionResult ProcessEntry(Entrys entry)
        {
            return _machine.ProcessEntry(entry);
        }

        public void Reset()
        {
            _machine.Reset();
        }
    }
}
