using System.Globalization;
using Microsoft.Maui.Controls;

namespace RecipeHub.Helpers;

public class BoolToSpeakTextConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value is bool isSpeaking ? (isSpeaking ? "停止播放" : "朗读步骤") : "朗读步骤";
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}