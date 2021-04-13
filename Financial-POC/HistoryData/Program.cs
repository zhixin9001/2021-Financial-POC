using System;

namespace HistoryData
{
  using System.Threading.Tasks;

  class Program
  {
    static async Task Main(string[] args)
    {
      var a = await ApiClient.RetriveHistoryData("161005", 10);
      Console.WriteLine(a);
    }
  }
}