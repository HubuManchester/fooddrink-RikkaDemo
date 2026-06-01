using System.ComponentModel;
using System.Runtime.CompilerServices;
using RecipeHub.Models;
using RecipeHub.Services;

namespace RecipeHub.ViewModels;

public class EditRecipeViewModel : ObservableObject
{
    private readonly IDataService _dataService;
    private readonly IHardwareService _hardwareService;

    private Recipe _recipe;
    public Recipe Recipe
    {
        get => _recipe;
        set => SetProperty(ref _recipe, value);
    }

    public string Title
    {
        get => _recipe.Title;
        set { _recipe.Title = value; OnPropertyChanged(); }
    }

    public string Description
    {
        get => _recipe.Description;
        set { _recipe.Description = value; OnPropertyChanged(); }
    }

    public string ImagePath
    {
        get => _recipe.ImagePath;
        set { _recipe.ImagePath = value; OnPropertyChanged(); }
    }

    public string Ingredients
    {
        get => string.Join('\n', _recipe.Ingredients);
        set { _recipe.Ingredients = value.Split('\n', StringSplitOptions.RemoveEmptyEntries).ToList(); OnPropertyChanged(); }
    }

    public string Instructions
    {
        get => string.Join('\n', _recipe.Instructions);
        set { _recipe.Instructions = value.Split('\n', StringSplitOptions.RemoveEmptyEntries).ToList(); OnPropertyChanged(); }
    }

    public int PrepTime
    {
        get => _recipe.PrepTime;
        set { _recipe.PrepTime = value; OnPropertyChanged(); }
    }

    public int CookTime
    {
        get => _recipe.CookTime;
        set { _recipe.CookTime = value; OnPropertyChanged(); }
    }

    public string Category
    {
        get => _recipe.Category;
        set { _recipe.Category = value; OnPropertyChanged(); }
    }

    public int Servings
    {
        get => _recipe.Servings;
        set { _recipe.Servings = value; OnPropertyChanged(); }
    }

    public string Difficulty
    {
        get => _recipe.Difficulty;
        set { _recipe.Difficulty = value; OnPropertyChanged(); }
    }

    public int Calories
    {
        get => (int)_recipe.Calories;
        set { _recipe.Calories = value; OnPropertyChanged(); }
    }

    public List<string> Categories { get; } = new List<string> { "Breakfast", "Lunch", "Dinner", "Dessert", "Drink" };
    public List<string> Difficulties { get; } = new List<string> { "Easy", "Medium", "Hard" };

    public EditRecipeViewModel(IDataService dataService, IHardwareService hardwareService, Recipe recipe)
    {
        _dataService = dataService;
        _hardwareService = hardwareService;
        _recipe = recipe;
    }

    public async Task SaveRecipeAsync()
    {
        if (string.IsNullOrWhiteSpace(Title))
        {
            await Application.Current!.MainPage!.DisplayAlert("Notice", "Please enter recipe name", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(Ingredients))
        {
            await Application.Current!.MainPage!.DisplayAlert("Notice", "Please enter ingredients", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(Instructions))
        {
            await Application.Current!.MainPage!.DisplayAlert("Notice", "Please enter instructions", "OK");
            return;
        }

        await _dataService.UpdateRecipeAsync(_recipe);
        await Application.Current!.MainPage!.DisplayAlert("Success", "Recipe updated successfully!", "OK");
        await Application.Current!.MainPage!.Navigation.PopAsync();
    }

    public async Task TakePhotoAsync()
    {
        var photoPath = await _hardwareService.TakePhotoAsync();
        if (!string.IsNullOrEmpty(photoPath))
        {
            ImagePath = photoPath;
        }
    }

    public async Task ResetToDefaultImageAsync()
    {
        var defaultImages = new Dictionary<int, string>
        {
            { 1, "food_1.png" },
            { 2, "food_2.png" },
            { 3, "food_3.png" },
            { 4, "food_4.png" },
            { 5, "food_5.png" },
            { 6, "food_6.png" }
        };

        if (defaultImages.ContainsKey(_recipe.Id))
        {
            ImagePath = defaultImages[_recipe.Id];
            await _dataService.UpdateRecipeAsync(_recipe);
            await Application.Current!.MainPage!.DisplayAlert("Success", "Default image restored", "OK");
        }
        else
        {
            await Application.Current!.MainPage!.DisplayAlert("Notice", "No default image available", "OK");
        }
    }
}