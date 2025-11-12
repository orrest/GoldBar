using GoldBar.Services;
using GoldBar.ViewModels;
using GoldBar.Views;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace GoldBar.Extensions;

internal static class DependencyInjectionExtensions
{
    public static IHostBuilder ConfigureAppServices(this IHostBuilder host)
    {
        var builder = host.ConfigureServices(
            (_, services) =>
            {
                services.AddSingleton<MainView>();
                services.AddSingleton<MainViewModel>();

                services.AddSingleton<SgeQuotationService>();
            }
        );

        return builder;
    }
}
