using desktop.Services.Auth;
using desktop.Services.Contract;
using desktop.Services.ContractFile;
using desktop.Services.RequestProvider;
using desktop.Services.Settings;
using desktop.Views;
using Microsoft.Extensions.Logging;

namespace desktop
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
                    fonts.AddFont("Sora-VariableFont_wght.ttf", "Sora");
                })
                .RegisterAppServices()
                .RegisterViews();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }

        public static MauiAppBuilder RegisterAppServices(this MauiAppBuilder app)
        {
            app.Services.AddSingleton<IRequestProvider, RequestProvider>();
            app.Services.AddSingleton<IAuthService, AuthService>();
            app.Services.AddSingleton<ISettingsService, SettingsService>();
            app.Services.AddSingleton<IContractService, ContractService>();
            app.Services.AddSingleton<IContractFileService, ContractFileService>();

            return app;
        }

        public static MauiAppBuilder RegisterViews(this MauiAppBuilder app)
        {
            app.Services.AddTransient<LoginView>();
            app.Services.AddTransient<RegisterView>();
            app.Services.AddTransient<MainPage>();
            app.Services.AddTransient<ContractsView>();
            app.Services.AddTransient<ContractSummaryView>();
            app.Services.AddTransient<ContractFilesView>();
            return app;
        }
    }
}
