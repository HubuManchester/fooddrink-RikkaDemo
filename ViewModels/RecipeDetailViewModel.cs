using System.ComponentModel;
using System.Runtime.CompilerServices;
using RecipeHub.Models;
using RecipeHub.Services;

namespace RecipeHub.ViewModels;

public class RecipeDetailViewModel : ObservableObject
{
    private readonly IDataService _dataService;
    private readonly IHardwareService _hardwareService;

    private Recipe _recipe;
    public Recipe Recipe
    {
        get => _recipe;
        set => SetProperty(ref _recipe, value);
    }

    private bool _isSpeaking;
    public bool IsSpeaking
    {
        get => _isSpeaking;
        set => SetProperty(ref _isSpeaking, value);
    }

    public RecipeDetailViewModel(IDataService dataService, IHardwareService hardwareService, Recipe recipe)
    {
        _dataService = dataService;
        _hardwareService = hardwareService;
        _recipe = recipe;
    }

    public async Task ToggleFavoriteAsync()
    {
        Recipe.IsFavorite = !Recipe.IsFavorite;
        await _dataService.UpdateRecipeAsync(Recipe);
    }

    public async Task TakePhotoAsync()
    {
        var photoPath = await _hardwareService.TakePhotoAsync();
        if (!string.IsNullOrEmpty(photoPath))
        {
            Recipe.ImagePath = photoPath;
            await _dataService.UpdateRecipeAsync(Recipe);
        }
    }

    public async Task SpeakInstructionsAsync()
    {
        if (IsSpeaking)
        {
            await _hardwareService.StopSpeakingAsync();
            IsSpeaking = false;
        }
        else
        {
            IsSpeaking = true;
            var instructionsText = string.Join("。", Recipe.Instructions);
            await _hardwareService.SpeakAsync($"{Recipe.Title}的制作步骤。{instructionsText}");
            IsSpeaking = false;
        }
    }

    public async Task StopSpeakingAsync()
    {
        await _hardwareService.StopSpeakingAsync();
        IsSpeaking = false;
    }

    public async Task DeleteRecipeAsync()
    {
        await _dataService.DeleteRecipeAsync(Recipe.Id);
    }
}