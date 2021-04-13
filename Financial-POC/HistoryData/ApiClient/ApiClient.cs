namespace HistoryData
{
  using System;
  using System.Net.Http;
  using System.Threading.Tasks;

  public class ApiClient
  {
    private static HttpClient httpClient = HttpClientFactory.Create();

    public static async Task<string> RetriveHistoryData(string code, int page, int per = 10)
    {
      httpClient.BaseAddress = new Uri("https://fundf10.eastmoney.com/F10DataApi.aspx");
      var responseMessage = await httpClient.GetAsync($"?type=lsjz&code={code}&per={per}&page={page}");
      return await responseMessage.Content.ReadAsStringAsync();
    }
  }
}