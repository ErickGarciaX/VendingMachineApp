using VendingMachineApp.Vistas;

namespace VendingMachineApp
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute("VendingMachine", typeof(VendingMachine));
        }
    }
}
