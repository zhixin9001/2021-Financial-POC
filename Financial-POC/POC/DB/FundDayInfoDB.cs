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

    public List<string[]> Data { get; set; }=new List<string[]>();

    public void InitDB()
    {
      using (StreamReader sr = new StreamReader(this.pathOfData))
      {
        string line;
        while ((line = sr.ReadLine()) != null)
        {
          Data.Add(line.Split(","));
        }
      }
    }
  }
}