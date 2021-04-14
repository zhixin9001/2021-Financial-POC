using System;

namespace HistoryData
{
  using System.Threading.Tasks;

  class Program
  {
    static async Task Main(string[] args)
    {
      var apiResponse = await ApiClient.RetriveHistoryData("161005", 10, 2);
      Console.WriteLine(apiResponse);
      //暂无数据
      var dataProcesser= new DataProcesser();
      dataProcesser.ExtractRows(apiResponse);
    }
  }
}