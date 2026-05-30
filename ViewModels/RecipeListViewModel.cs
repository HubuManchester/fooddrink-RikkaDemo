using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using RecipeHub.Models;
using RecipeHub.Services;

namespace RecipeHub.ViewModels;

public class RecipeListViewModel : ObservableObject
{
    private readonly IDataService _dataService;
    private readonly INavigationService _navigationService;
    private List<Recipe> _allRecipes;

    private ObservableCollection<Recipe> _recipes;
    public ObservableCollection<Recipe> Recipes
    {
        get => _recipes;
        set => SetProperty(ref _recipes, value);
    }

    private string _searchText = string.Empty;
    public string SearchText
    {
        get => _searchText;
        set
        {
            if (SetProperty(ref _searchText, value))
            {
                FilterRecipes();
            }
        }
    }

    private Category? _selectedCategory;
    public Category? SelectedCategory
    {
        get => _selectedCategory;
        set
        {
            if (SetProperty(ref _selectedCategory, value))
            {
                FilterRecipes();
            }
        }
    }

    private bool _isLoading;
    public bool IsLoading
    {
        get => _isLoading;
        set => SetProperty(ref _isLoading, value);
    }

    private bool _isDarkMode;
    public bool IsDarkMode
    {
        get => _isDarkMode;
        set
        {
            if (SetProperty(ref _isDarkMode, value))
            {
                Application.Current!.UserAppTheme = value ? AppTheme.Dark : AppTheme.Light;
            }
        }
    }

    public ObservableCollection<Category> Categories { get; } = new()
    {
        new Category { Name = "全部", Icon = "🍽️" },
        new Category { Name = "早餐", Icon = "🥞" },
        new Category { Name = "午餐", Icon = "🍱" },
        new Category { Name = "晚餐", Icon = "🍝" },
        new Category { Name = "甜点", Icon = "🍰" },
        new Category { Name = "饮品", Icon = "🥤" }
    };

    public RecipeListViewModel(IDataService dataService, INavigationService navigationService)
    {
        _dataService = dataService;
        _navigationService = navigationService;
        _recipes = new ObservableCollection<Recipe>();
        _allRecipes = new List<Recipe>();
        IsDarkMode = Application.Current!.RequestedTheme == AppTheme.Dark;
    }

    public async Task LoadRecipesAsync()
    {
        IsLoading = true;
        try
        {
            _allRecipes = await _dataService.GetRecipesAsync();
            Recipes = new ObservableCollection<Recipe>(_allRecipes);
            SelectedCategory = Categories[0];
            UpdateFilteredRecipes();
        }
        catch (Exception ex)
        {
            await Application.Current!.MainPage!.DisplayAlert("错误", $"加载食谱失败: {ex.Message}", "确定");
        }
        finally
        {
            IsLoading = false;
        }
    }

    public async Task ToggleFavoriteAsync(Recipe recipe)
    {
        recipe.IsFavorite = !recipe.IsFavorite;
        await _dataService.UpdateRecipeAsync(recipe);
    }

    public async Task GoToDetailAsync(Recipe recipe)
    {
        await _navigationService.NavigateToAsync<RecipeDetailViewModel>(recipe);
    }

    private void FilterRecipes()
    {
        var filtered = _allRecipes.AsEnumerable();

        if (!string.IsNullOrWhiteSpace(SearchText))
        {
            var searchLower = SearchText.ToLower();
            filtered = filtered.Where(r =>
                r.Title.ToLower().Contains(searchLower) ||
                r.Description.ToLower().Contains(searchLower) ||
                r.Ingredients.Any(i => i.ToLower().Contains(searchLower)));
        }

        if (SelectedCategory != null && SelectedCategory.Name != "全部")
        {
            filtered = filtered.Where(r => r.Category == SelectedCategory.Name);
        }

        Recipes.Clear();
        foreach (var recipe in filtered)
        {
            Recipes.Add(recipe);
        }
    }

    private void UpdateFilteredRecipes()
    {
        var filtered = _allRecipes.AsEnumerable();

        if (!string.IsNullOrWhiteSpace(SearchText))
        {
            var searchLower = SearchText.ToLower();
            filtered = filtered.Where(r =>
                r.Title.ToLower().Contains(searchLower) ||
                r.Description.ToLower().Contains(searchLower) ||
                r.Ingredients.Any(i => i.ToLower().Contains(searchLower)));
        }

        if (SelectedCategory != null && SelectedCategory.Name != "全部")
        {
            filtered = filtered.Where(r => r.Category == SelectedCategory.Name);
        }

        Recipes.Clear();
        foreach (var recipe in filtered)
        {
            Recipes.Add(recipe);
        }
    }

    public async Task HandleShakeAsync()
    {
        var random = new Random();
        var randomIndex = random.Next(_allRecipes.Count);
        var randomRecipe = _allRecipes[randomIndex];
        await GoToDetailAsync(randomRecipe);
    }
}