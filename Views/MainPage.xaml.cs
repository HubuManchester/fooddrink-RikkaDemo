using Microsoft.Extensions.DependencyInjection;
using RecipeHub.Models;
using RecipeHub.Services;
using RecipeHub.ViewModels;

namespace RecipeHub.Views;

public partial class MainPage : ContentPage
{
    private readonly RecipeListViewModel _viewModel;
    private readonly IHardwareService _hardwareService;

    public MainPage(RecipeListViewModel viewModel, IHardwareService hardwareService)
    {
        InitializeComponent();
        _viewModel = viewModel;
        _hardwareService = hardwareService;
        BindingContext = _viewModel;
        Loaded += OnLoaded;
    }

    private async void OnLoaded(object? sender, EventArgs e)
    {
        await _viewModel.LoadRecipesAsync();
        await _hardwareService.StartAccelerometerAsync(async () => await _viewModel.HandleShakeAsync());
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await _viewModel.LoadRecipesAsync();
    }

    private void OnCategoryTapped(object? sender, TappedEventArgs e)
    {
        if (sender is Frame frame && frame.BindingContext is Category category)
        {
            _viewModel.SelectedCategory = category;
        }
    }

    private async void OnRecipeTapped(object? sender, TappedEventArgs e)
    {
        if (sender is Frame frame && frame.BindingContext is Recipe recipe)
        {
            await _viewModel.GoToDetailAsync(recipe);
        }
    }

    private async void OnFavoriteTapped(object? sender, TappedEventArgs e)
    {
        if (sender is ImageButton button && button.BindingContext is Recipe recipe)
        {
            await _viewModel.ToggleFavoriteAsync(recipe);
        }
    }

    private void OnDarkModeTapped(object? sender, TappedEventArgs e)
    {
        _viewModel.IsDarkMode = !_viewModel.IsDarkMode;
    }

    private async void OnShakeClicked(object? sender, EventArgs e)
    {
        await _viewModel.HandleShakeAsync();
    }

    private async void OnAddRecipeClicked(object? sender, EventArgs e)
    {
        var addViewModel = App.Current!.Handler.MauiContext!.Services.GetRequiredService<AddRecipeViewModel>();
        var addPage = new Views.AddRecipePage(addViewModel);
        await Navigation.PushAsync(addPage);
    }
}