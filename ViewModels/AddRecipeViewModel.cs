using System.ComponentModel;
using System.Runtime.CompilerServices;
using RecipeHub.Models;
using RecipeHub.Services;

namespace RecipeHub.ViewModels;

public class AddRecipeViewModel : ObservableObject
{
    private readonly IDataService _dataService;
    private readonly IHardwareService _hardwareService;
    private readonly INavigationService _navigationService;

    private string _title = string.Empty;
    public string Title
    {
        get => _title;
        set => SetProperty(ref _title, value);
    }

    private string _description = string.Empty;
    public string Description
    {
        get => _description;
        set => SetProperty(ref _description, value);
    }

    private string _imagePath = "food_1.png";
    public string ImagePath
    {
        get => _imagePath;
        set => SetProperty(ref _imagePath, value);
    }

    private string _ingredients = string.Empty;
    public string Ingredients
    {
        get => _ingredients;
        set => SetProperty(ref _ingredients, value);
    }

    private string _instructions = string.Empty;
    public string Instructions
    {
        get => _instructions;
        set => SetProperty(ref _instructions, value);
    }

    private int _prepTime = 10;
    public int PrepTime
    {
        get => _prepTime;
        set => SetProperty(ref _prepTime, value);
    }

    private int _cookTime = 10;
    public int CookTime
    {
        get => _cookTime;
        set => SetProperty(ref _cookTime, value);
    }

    private string _category = "早餐";
    public string Category
    {
        get => _category;
        set => SetProperty(ref _category, value);
    }

    private int _servings = 1;
    public int Servings
    {
        get => _servings;
        set => SetProperty(ref _servings, value);
    }

    private string _difficulty = "简单";
    public string Difficulty
    {
        get => _difficulty;
        set => SetProperty(ref _difficulty, value);
    }

    private int _calories = 200;
    public int Calories
    {
        get => _calories;
        set => SetProperty(ref _calories, value);
    }

    public List<string> Categories { get; } = new List<string> { "早餐", "午餐", "晚餐", "甜点", "饮品" };
    public List<string> Difficulties { get; } = new List<string> { "简单", "中等", "困难" };

    public AddRecipeViewModel(IDataService dataService, IHardwareService hardwareService, INavigationService navigationService)
    {
        _dataService = dataService;
        _hardwareService = hardwareService;
        _navigationService = navigationService;
    }

    public async Task SaveRecipeAsync()
    {
        if (string.IsNullOrWhiteSpace(Title))
        {
            await Application.Current!.MainPage!.DisplayAlert("提示", "请输入食谱名称", "确定");
            return;
        }

        if (string.IsNullOrWhiteSpace(Ingredients))
        {
            await Application.Current!.MainPage!.DisplayAlert("提示", "请输入食材", "确定");
            return;
        }

        if (string.IsNullOrWhiteSpace(Instructions))
        {
            await Application.Current!.MainPage!.DisplayAlert("提示", "请输入制作步骤", "确定");
            return;
        }

        var recipe = new Recipe
        {
            Title = Title,
            Description = Description,
            ImagePath = ImagePath,
            Ingredients = Ingredients.Split('\n', StringSplitOptions.RemoveEmptyEntries).ToList(),
            Instructions = Instructions.Split('\n', StringSplitOptions.RemoveEmptyEntries).ToList(),
            PrepTime = PrepTime,
            CookTime = CookTime,
            Category = Category,
            Servings = Servings,
            Difficulty = Difficulty,
            Calories = Calories,
            IsFavorite = false
        };

        await _dataService.AddRecipeAsync(recipe);
        await Application.Current!.MainPage!.DisplayAlert("成功", "食谱添加成功！", "确定");
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

    public async Task GoBackAsync()
    {
        await Application.Current!.MainPage!.Navigation.PopAsync();
    }
}