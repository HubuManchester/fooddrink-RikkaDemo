using Microsoft.Extensions.DependencyInjection;
using RecipeHub.ViewModels;

namespace RecipeHub;

public partial class App : Application
{
    private readonly IServiceProvider _serviceProvider;

    public App(IServiceProvider serviceProvider)
    {
        InitializeComponent();
        _serviceProvider = serviceProvider;
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        var viewModel = _serviceProvider.GetRequiredService<RecipeListViewModel>();
        return new Window(new AppShell(_serviceProvider, viewModel));
    }
}