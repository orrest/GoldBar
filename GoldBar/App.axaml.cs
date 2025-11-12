using System;
using System.Windows.Input;
using Avalonia;
using Avalonia.Controls.ApplicationLifetimes;
using Avalonia.Markup.Xaml;
using CommunityToolkit.Mvvm.Input;
using GoldBar.Extensions;
using GoldBar.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GoldBar;

public partial class App : Application
{
    public static IHost Host { get; private set; } = null!;

    public ICommand ExitCommand { get; private set; }

    private void Exit()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            desktop.Shutdown();
        }
    }

    public App()
    {
        DataContext = this;
        ExitCommand = new RelayCommand(Exit);

        Host = Microsoft
            .Extensions.Hosting.Host.CreateDefaultBuilder()
            .ConfigureAppServices()
            .Build();
    }

    public override void Initialize()
    {
        AvaloniaXamlLoader.Load(this);
    }

    public override void OnFrameworkInitializationCompleted()
    {
        if (ApplicationLifetime is IClassicDesktopStyleApplicationLifetime desktop)
        {
            var main = App.Host.Services.GetRequiredService<MainView>();
            desktop.MainWindow = main;
        }

        base.OnFrameworkInitializationCompleted();
    }
}
