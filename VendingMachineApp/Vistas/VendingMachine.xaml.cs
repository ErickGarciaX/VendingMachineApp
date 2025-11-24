using VendingMachineApp.Presentation.ViewModels;

namespace VendingMachineApp.Vistas;

public partial class VendingMachine : ContentPage
{
    public VendingMachine(VendingMachineViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }

    private async void BtnBack_Pressed(object sender, EventArgs e)
    {
        BtnBack.Opacity = 0;
        await BtnBack.FadeTo(1, 200);


        await Shell.Current.Navigation.PopAsync();
    }
}
