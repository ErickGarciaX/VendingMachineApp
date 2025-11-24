using VendingMachineApp.Vistas;

namespace VendingMachineApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            CounterBtn.Opacity = 0;
            await CounterBtn.FadeTo(1, 200);

            await Shell.Current.GoToAsync("VendingMachine");

        }
    }
}
