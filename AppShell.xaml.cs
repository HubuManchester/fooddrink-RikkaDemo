using Microsoft.Extensions.DependencyInjection;
using RecipeHub.ViewModels;
using RecipeHub.Views;

namespace RecipeHub;

public partial class AppShell : Shell
{
    public AppShell(IServiceProvider serviceProvider, RecipeListViewModel viewModel)
    {
        var mainPage = new MainPage(viewModel, serviceProvider.GetRequiredService<Services.IHardwareService>());
        Items.Add(new ShellContent
        {
            Title = "食谱",
            ContentTemplate = new DataTemplate(() => mainPage),
            Route = "MainPage"
        });
    }
}
