namespace HistoryData
{
  using System;
  using System.Collections.Generic;
  using System.Linq;
  using System.Text;
  using System.Text.RegularExpressions;

  public class DataProcesser
  {
    public string ExtractRows(string apiResponse)
    {
      var result = new StringBuilder();
      var tBody = ExtactTBody(apiResponse);
      var trList = ExtractTRs(tBody);
      foreach (var tr in trList)
      {
        var tdList = ExtractTDs(tr);
        result.AppendLine(string.Join(",",tdList));
      }

      return result.ToString();
    }

    private string ExtactTBody(string apiResponse)
    {
      var firstTR = apiResponse.IndexOf("<tr>");
      var lastTR = apiResponse.LastIndexOf("</td>");
      return apiResponse.Substring(firstTR, lastTR - firstTR);
    }

    private List<string> ExtractTRs(string tBody)
    {
      var TRs = tBody.Split("</tr>");

      var results = new List<string>();
      for (int i = 1; i < TRs.Length; i++)
      {
        results.Add(TRs[i]);
      }

      return results;
    }

    private List<string> ExtractTDs(string tBody)
    {
      var TDs = tBody.Split("</td>");
      Regex regex = new Regex("<td.*>(.+)");
      var results = new List<string>();
      int count = 0;
      foreach (var td in TDs)
      {
        if (count == 3) break;
        var value = regex.Match(td);
        results.Add(value.Groups[1].Value);
        count++;
      }

      return results;
    }
  }
}