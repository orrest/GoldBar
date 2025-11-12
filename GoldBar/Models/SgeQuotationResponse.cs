using System;
using System.Globalization;

namespace GoldBar.Models;

public class SgeQuotationResponse
{
    public string[] Times { get; set; }

    public int Min { get; set; }

    public string[] Data { get; set; }

    public int Max { get; set; }

    public string Heyue { get; set; }

    public string DelayStr { get; set; }

    public DateTime Time
    {
        get
        {
            DateTime dt = DateTime.ParseExact(
                DelayStr,
                "yyyy年MM月dd日 HH:mm:ss",
                CultureInfo.InvariantCulture
            );
            return dt;
        }
    }
}
