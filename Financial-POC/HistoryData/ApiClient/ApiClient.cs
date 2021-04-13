namespace HistoryData
{
  using System;
  using System.Net.Http;
  using System.Threading.Tasks;

  public class ApiClient
  {
    public static async Task<string> test()
    {

      var a =HttpClientFactory.Create();
      a.BaseAddress =new Uri("https://fundf10.eastmoney.com/F10DataApi.aspx?type=lsjz&code=161005&per=2&page=1");
      var b=  await a.GetAsync("");
      return await b.Content.ReadAsStringAsync();
    }
    
  }
}