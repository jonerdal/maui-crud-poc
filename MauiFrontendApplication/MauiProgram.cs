using MauiFrontendApplication.DataServices;
using MauiFrontendApplication.Pages;

namespace MauiFrontendApplication
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

            //TODO fix this with client factory
            builder.Services.AddSingleton<ILocationsDataService, LocationsDataService>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddTransient<ManageLocationsPage>();

            return builder.Build();
        }
    }
}