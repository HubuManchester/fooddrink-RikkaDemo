using Microsoft.Extensions.Logging;
using RecipeHub.Services;
using RecipeHub.ViewModels;

namespace RecipeHub;

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

		builder.Services.AddSingleton<IDataService, JsonDataService>();
		builder.Services.AddSingleton<INavigationService, NavigationService>();
		builder.Services.AddSingleton<IHardwareService, HardwareService>();
		builder.Services.AddSingleton<RecipeListViewModel>();
		builder.Services.AddTransient<RecipeDetailViewModel>();
		builder.Services.AddTransient<AddRecipeViewModel>();
		builder.Services.AddTransient<EditRecipeViewModel>();

		return builder.Build();
	}
}
