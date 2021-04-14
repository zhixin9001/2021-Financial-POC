namespace HistoryData
{
  using System;
  using System.Net.Http;
  using System.Threading.Tasks;

  public class ApiClient
  {
    private static HttpClient httpClient;

    static ApiClient()
    {
      httpClient = HttpClientFactory.Create();
      // httpClient.DefaultRequestHeaders.Add("User-Agent",
      //   "Mozilla/5.0 (Macintosh; Intel Mac OS X 10_15_7) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/89.0.4389.82 Safari/537.36");
      // httpClient.DefaultRequestHeaders.Add("Accept",
      //   "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.9");
      // httpClient.DefaultRequestHeaders.Add("Sec-Fetch-Mode",
      //   "navigate");
      // httpClient.DefaultRequestHeaders.Add("Accept-Encoding",
      //   "gzip, deflate, br");
      // httpClient.DefaultRequestHeaders.Add("Cookie",
      //   "ASP.NET_SessionId=2xmg2n4pvgwnu1yuyafwylwb");
      // httpClient.DefaultRequestHeaders.Add("sec-ch-ua",
      //   "\"Google Chrome\";v=\"89\", \"Chromium\";v=\"89\", \";Not A Brand\";v=\"99\"");
      // httpClient.DefaultRequestHeaders.Add("sec-ch-ua-mobile",
      //   "?0");
      // httpClient.DefaultRequestHeaders.Add("Upgrade-Insecure-Requests",
      //   "1");
      // httpClient.DefaultRequestHeaders.Add("Sec-Fetch-Site",
      //   "none");
      // httpClient.DefaultRequestHeaders.Add("Sec-Fetch-User",
      //   "?1");
      // httpClient.DefaultRequestHeaders.Add("Sec-Fetch-Dest",
      //   "document");
      // httpClient.DefaultRequestHeaders.Add("Accept-Language",
      //   "en-US,en;q=0.9");
    }  
      
    public static async Task<string> RetriveHistoryData(string code, int page, int per = 10)
    {
      httpClient.BaseAddress = new Uri("https://fundf10.eastmoney.com/F10DataApi.aspx");
      var responseMessage = await httpClient.GetAsync($"?type=lsjz&code={code}&per={per}&page={page}");
      return await responseMessage.Content.ReadAsStringAsync();
    }
  }
}