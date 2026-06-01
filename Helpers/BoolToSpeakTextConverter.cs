using System.Globalization;
using Microsoft.Maui.Controls;

namespace RecipeHub.Helpers;

public class BoolToSpeakTextConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value is bool isSpeaking ? (isSpeaking ? "Stop" : "Read") : "Read";
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}