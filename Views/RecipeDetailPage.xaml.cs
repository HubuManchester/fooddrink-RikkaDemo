using RecipeHub.Models;
using RecipeHub.Services;
using RecipeHub.ViewModels;

namespace RecipeHub.Views;

public partial class RecipeDetailPage : ContentPage
{
    private readonly RecipeDetailViewModel _viewModel;

    public RecipeDetailPage(RecipeDetailViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    private async void OnBackClicked(object? sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void OnFavoriteTapped(object? sender, TappedEventArgs e)
    {
        await _viewModel.ToggleFavoriteAsync();
    }

    private async void OnTakePhotoClicked(object? sender, EventArgs e)
    {
        await _viewModel.TakePhotoAsync();
    }

    private async void OnSpeakClicked(object? sender, EventArgs e)
    {
        await _viewModel.SpeakInstructionsAsync();
    }

    private async void OnStopSpeakingClicked(object? sender, EventArgs e)
    {
        await _viewModel.StopSpeakingAsync();
    }

    private async void OnEditClicked(object? sender, EventArgs e)
    {
        var editViewModel = new ViewModels.EditRecipeViewModel(
            App.Current!.Handler.MauiContext!.Services.GetRequiredService<IDataService>(),
            App.Current!.Handler.MauiContext!.Services.GetRequiredService<IHardwareService>(),
            _viewModel.Recipe
        );
        var editPage = new EditRecipePage(editViewModel);
        await Navigation.PushAsync(editPage);
    }

    private async void OnDeleteClicked(object? sender, EventArgs e)
    {
        var result = await DisplayAlert("确认删除", "确定要删除这个食谱吗？", "删除", "取消");
        if (result)
        {
            await _viewModel.DeleteRecipeAsync();
            await Navigation.PopAsync();
        }
    }
}