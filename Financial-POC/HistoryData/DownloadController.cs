
namespace HistoryData
{
    using System;
    using System.IO;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    public class DownloadController
  {
    public static async Task Begin(string code, string fundName)
    {      
      var dataProcesser= new DataProcesser();
      int pageIndex=1;
      string apiResponse=await ApiClient.RetriveHistoryData(code, pageIndex, per:40);
      var stringBuilder=new StringBuilder();
      while(!IsNoData(apiResponse))
      {
        pageIndex++;
        Thread.Sleep(3*1000);
        var rows= dataProcesser.ExtractRows(apiResponse);
        stringBuilder.Append(rows);
        Console.WriteLine(pageIndex);
        apiResponse = await ApiClient.RetriveHistoryData(code, pageIndex, per:40);
      }
      if(stringBuilder.Length>0){
        FileHelper.WriteAndSave($"./历史净值-{fundName}.csv",stringBuilder.ToString());
      }
      
    }

    private static bool IsNoData(string apiResponse)
    {
      return apiResponse.Contains("暂无数据");
    }
  }
}