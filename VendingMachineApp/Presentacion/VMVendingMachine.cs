using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using VendingMachineApp.Application.Interfaces;
using VendingMachineApp.Domain.Entities;

namespace VendingMachineApp.Presentation.ViewModels;

public partial class VendingMachineViewModel : ObservableObject
{
    private readonly IStateMachineService _stateMachine;

    // Constructor recibe el servicio 
    public VendingMachineViewModel(IStateMachineService stateMachine)
    {
        _stateMachine = stateMachine;
        UpdateStateUI();
    }

    // PROPIEDADES QUE SE MUESTRAN EN LA UI

    [ObservableProperty]
    private string currentStateText = "Monto: 0";

    [ObservableProperty]
    private string lastMessage = "Listo";

    // COMANDOS QUE EJECUTAN ACCIONES DESDE LA UI


    [RelayCommand]
    private void InsertCoin1() => Process(Entrys.Coin1);

    [RelayCommand]
    private void InsertCoin2() => Process(Entrys.Coin2);

    [RelayCommand]
    private void InsertCoin5() => Process(Entrys.Coin5);

    [RelayCommand]
    private void InsertCoin10() => Process(Entrys.Coin10);

    [RelayCommand]
    private void BuyA() => Process(Entrys.buttonBuyA);

    [RelayCommand]
    private void BuyB() => Process(Entrys.buttonBuyB);

    [RelayCommand]
    private void Cancel() => Process(Entrys.buttonCancel);

    [RelayCommand]
    private void Reset()
    {
        _stateMachine.Reset();
        UpdateStateUI();
        LastMessage = "Maquina Reiniciada.";
    }

    // LOGICA CENTRAL PARA LLAMAR AL SERVICIO


    private void Process(Entrys entry)
    {
        var result = _stateMachine.ProcessEntry(entry);

        // Actualizar texto en pantalla
        LastMessage = result.MessageOutput;

        UpdateStateUI();

        // Si el estado fue dispense o returnChange, reiniciar automaticamente
        if (result.NewState == States.dispenseA ||
            result.NewState == States.dispenseB ||
            result.NewState == States.returnChange)
        {
            Task.Delay(1000).ContinueWith(_ =>
            {
                _stateMachine.Reset();
                UpdateStateUI();
            });
        }
    }

    private void UpdateStateUI()
    {
        var cs = _stateMachine.CurrentState;

        if ((int)cs <= 20)
        {
            CurrentStateText = $"Balance: {(int)cs}";
        }
        else
        {
            CurrentStateText = cs.ToString();
        }
    }
}
