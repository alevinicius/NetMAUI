using MauiApp1.ViewModel;
using Microsoft.Extensions.Logging;

namespace MauiApp1;

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
#endif

        //Singleton será utilizada durante toda a execução do programa uma única instância
        builder.Services.AddSingleton<IConnectivity>(Connectivity.Current);

		builder.Services.AddSingleton<MainPage>();
		builder.Services.AddSingleton<MainViewModel>();

		//Transient será criado e destruído conforme usamos
		builder.Services.AddTransient<DetailPage>();
		builder.Services.AddTransient<DetailViewModel>();

		return builder.Build();
	}
}
