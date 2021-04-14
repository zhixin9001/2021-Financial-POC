using System;

namespace HistoryData
{
  using System.Threading.Tasks;
//https://fundf10.eastmoney.com/F10DataApi.aspx?type=lsjz&code=161005&per=10&page=1
  class Program
  {
    static async Task Main(string[] args)
    {
    //  await DownloadController.Begin("161005","富国天慧161005");
     await DownloadController.Begin("519671","银河沪深300-519671");
    }
  }
}