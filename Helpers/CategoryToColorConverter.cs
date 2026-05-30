using System.Globalization;
using Microsoft.Maui.Controls;
using RecipeHub.Models;

namespace RecipeHub.Helpers;

public class CategoryToColorConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is Category category && Application.Current?.MainPage?.BindingContext is RecipeHub.ViewModels.RecipeListViewModel viewModel)
        {
            var selectedCategory = viewModel.SelectedCategory;
            if (selectedCategory?.Name == category.Name)
            {
                return Color.FromArgb("#512BD4");
            }
        }
        return Color.FromArgb("#F0F0F0");
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}