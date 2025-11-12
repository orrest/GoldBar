using System;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using GoldBar.Models;
using GoldBar.Services;

namespace GoldBar.ViewModels;

public partial class MainViewModel : ObservableObject
{
    private readonly SgeQuotationService api;
    private readonly System.Timers.Timer timer;

    private volatile bool isFetching;

    [ObservableProperty]
    public partial double Price { get; set; }

    [ObservableProperty]
    public partial string TimeStr { get; set; } = string.Empty;

    public MainViewModel(SgeQuotationService api)
    {
        this.api = api;

        timer = new System.Timers.Timer(TimeSpan.FromSeconds(60));
        timer.Elapsed += async (sender, e) => await GetCurrentPrice();
        timer.AutoReset = true;
        timer.Enabled = true;

        GetCurrentPriceCommand.Execute(null);
    }

    [RelayCommand]
    private async Task GetCurrentPrice()
    {
        try
        {
            if (isFetching)
            {
                return;
            }

            isFetching = true;

            SgeQuotationItem? goldPrice = await this.api.GetCurrentPriceAsync();
            if (goldPrice is not null)
            {
                Price = (double)goldPrice.Price!;
                TimeStr = goldPrice.TimeStr;
            }
        }
        catch (Exception e)
        {
            ;
        }
        finally
        {
            isFetching = false;
        }
    }
}
