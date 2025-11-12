using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GoldBar.Models;
using Refit;

namespace GoldBar.Services;

public class SgeQuotationService
{
    private ISgeApi api;

    public SgeQuotationService()
    {
        api = RestService.For<ISgeApi>("https://www.sge.com.cn");
    }

    public async Task<SgeQuotationItem?> GetCurrentPriceAsync(string symbol = "Au99.99")
    {
        var payload = new Dictionary<string, string>() { { "intsid", symbol } };

        SgeQuotationResponse response = await this.api.GetSpotQuotationsAsync(payload);

        DateTime time = response.Time;
        // The api is not real-time.
        time = time.AddMinutes(-3);
        var hhmm = $"{time.Hour:D2}:{time.Minute:D2}";

        int index = response.Times.IndexOf(hhmm);
        if (index == -1)
        {
            return null;
        }

        var price = response.Data[index];

        var res = new SgeQuotationItem()
        {
            Price = double.Parse(price),
            Symbol = symbol,
            TimeStr = time.ToLongTimeString(),
        };

        return res;
    }
}
