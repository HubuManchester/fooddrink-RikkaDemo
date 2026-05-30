using RecipeHub.Models;

namespace RecipeHub.Services;

public interface INavigationService
{
    Task NavigateToAsync<TViewModel>(object? parameter = null) where TViewModel : class;
}