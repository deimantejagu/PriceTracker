using PriceTracker.Services;
using PriceTracker.ViewModels;
using PriceTracker.Views;

namespace PriceTracker;

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
            });

        builder.Services.AddSingleton<JsonDataReader>();
        builder.Services.AddSingleton<Filters>();

        builder.Services.AddTransient<BaseViewModel>();
        builder.Services.AddTransient<FilterViewModel>();
        builder.Services.AddTransient<GasStationDataViewModel>();

        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<FilterPage>();
        builder.Services.AddTransient<LoginPage>();

        return builder.Build();
    }
}
