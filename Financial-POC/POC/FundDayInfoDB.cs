namespace POC
{
  using System;
  using System.Collections.Generic;
  using System.IO;

  public class FundDayInfoDB
  {
    private string pathOfData;

    public FundDayInfoDB(string pathOfData)
    {
      this.pathOfData = pathOfData;
    }

    public string[][] Data { get; set; }

    public void InitDB()
    {
      var fundDayInfoList = new List<string[]>();
      using (StreamReader sr = new StreamReader(this.pathOfData))
      {
        string line;
        while ((line = sr.ReadLine()) != null)
        {
          fundDayInfoList.Add(line.Split(","));
        }
      }

      if (fundDayInfoList.Count > 0)
      {
        Data = new string[fundDayInfoList.Count][];
        fundDayInfoList.CopyTo(Data);
      }
    }
  }
}