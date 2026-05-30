using Microsoft.Extensions.DependencyInjection;
using RecipeHub.Models;
using RecipeHub.Services;
using RecipeHub.ViewModels;
using RecipeHub.Views;

namespace RecipeHub.Services;

public class NavigationService : INavigationService
{
    private readonly IServiceProvider _serviceProvider;

    public NavigationService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

	public async Task NavigateToAsync<TViewModel>(object? parameter = null) where TViewModel : class
	{
		if (typeof(TViewModel) == typeof(RecipeDetailViewModel) && parameter is Recipe recipe)
		{
			var dataService = _serviceProvider.GetRequiredService<IDataService>();
			var hardwareService = _serviceProvider.GetRequiredService<IHardwareService>();
			var viewModel = new RecipeDetailViewModel(dataService, hardwareService, recipe);
			var page = new Views.RecipeDetailPage(viewModel);
			await Application.Current!.MainPage!.Navigation.PushAsync(page);
		}
	}
}