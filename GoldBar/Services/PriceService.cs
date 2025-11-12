using GoldBar.Models;
using Refit;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GoldBar.Services;

public interface ISgeApi
{
    [Headers(
        "Accept: application/json, text/javascript, */*; q=0.01",
        "Accept-Language: en,en-US;q=0.9,zh-CN;q=0.8,zh;q=0.7,en-GB;q=0.6,en-GB-oxendict;q=0.5",
        "Cache-Control: no-cache",
        "Connection: keep-alive",
        "Content-Length: 14",
        "Content-Type: application/x-www-form-urlencoded; charset=UTF-8",
        "DNT: 1",
        "Host: www.sge.com.cn",
        "Origin: https://www.sge.com.cn",
        "Pragma: no-cache",
        "Referer: https://www.sge.com.cn/",
        "Sec-Fetch-Dest: empty",
        "Sec-Fetch-Mode: cors",
        "Sec-Fetch-Site: same-origin",
        "User-Agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/142.0.0.0 Safari/537.36 Edg/142.0.0.0",
        "X-Requested-With: XMLHttpRequest",
        @"sec-ch-ua: ""Chromium"";v=""142"", ""Microsoft Edge"";v =""142"", ""Not_A Brand"";v =""99""",
        "sec -ch-ua-mobile: ?0",
        @"sec-ch-ua-platform: ""Windows"""
    )]
    [Post("/graph/quotations")]
    Task<SgeQuotationResponse> GetSpotQuotationsAsync(
        [Body(BodySerializationMethod.UrlEncoded)] Dictionary<string, string> payload
    );
}
