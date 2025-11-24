using Microsoft.Extensions.Logging;
using VendingMachineApp.Application.Interfaces;
using VendingMachineApp.Infraestructure.Service;
using VendingMachineApp.Presentation.ViewModels;
using VendingMachineApp.Vistas;

namespace VendingMachineApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
            
            builder.Logging.AddDebug();

            builder.Services.AddSingleton<IStateMachineService, StateMachineService>();
            builder.Services.AddTransient<VendingMachineViewModel>();
            builder.Services.AddTransient<VendingMachine>();
#endif

            return builder.Build();
        }
    }
}
