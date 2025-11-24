
namespace VendingMachineApp.Domain.Entities
{
    public class StateMachine
    {
        public States CurrentState { get; private set; } = States.balance0;

        private int Balance => (int)CurrentState;

        public TransitionResult ProcessEntry(Entrys entry)
        {
            switch (entry)
            {
                // MONEDAS
                case Entrys.Coin1:
                    return AddMoney(1);

                case Entrys.Coin2:
                    return AddMoney(2);

                case Entrys.Coin5:
                    return AddMoney(5);

                case Entrys.Coin10:
                    return AddMoney(10);

                // COMPRAR

                case Entrys.buttonBuyA:
                    return BuyProduct(cost: 12, successState: States.dispenseA);

                case Entrys.buttonBuyB:
                    return BuyProduct(cost: 15, successState: States.dispenseB);


                // CANCELAR

                case Entrys.buttonCancel:
                    CurrentState = States.returnChange;
                    return new TransitionResult(CurrentState, true, $"Devolver: {Balance}");

                default:
                    return new TransitionResult(CurrentState, false, "Entrada no valida.");
            }
        }


        // Helpers


        private TransitionResult AddMoney(int amount)
        {
            int newBalance = Balance + amount;

            if (newBalance > 20)
            {
                return new TransitionResult(CurrentState, false, "Monto maximo es de 20.");
            }

            CurrentState = (States)newBalance;

            return new TransitionResult(CurrentState, true, $"Monto: {newBalance}");
        }


        private TransitionResult BuyProduct(int cost, States successState)
        {
            if (Balance < cost)
            {
                return new TransitionResult(CurrentState, false, "Monto Insuficiente.");
            }

            CurrentState = successState;

            return new TransitionResult(CurrentState, true, "Producto entregado.");
        }

        public void Reset()
        {
            CurrentState = States.balance0;
        }
    }
}
