using RecipeHub.ViewModels;

namespace RecipeHub.Views;

public partial class AddRecipePage : ContentPage
{
    private readonly AddRecipeViewModel _viewModel;

    public AddRecipePage(AddRecipeViewModel viewModel)
    {
        InitializeComponent();
        _viewModel = viewModel;
        BindingContext = _viewModel;
    }

    private async void OnBackClicked(object? sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

    private async void OnSaveClicked(object? sender, EventArgs e)
    {
        await _viewModel.SaveRecipeAsync();
    }

    private async void OnTakePhotoClicked(object? sender, EventArgs e)
    {
        await _viewModel.TakePhotoAsync();
    }
}