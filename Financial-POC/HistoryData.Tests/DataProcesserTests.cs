using NUnit.Framework;

namespace HistoryData.Tests
{
  using System;

  public class DataProcesserTests
  {
    [SetUp]
    public void Setup()
    {
    }

    [Test]
    public void ExtractRows_ShouldExtractCrrectly()
    {
      var mockResponse = FileHelper.Read("./data/historyData-2.txt");
      var processer = new DataProcesser();
      var result = processer.ExtractRows(mockResponse);
      Assert.AreEqual(result, $"2021-03-17,3.5809,6.4789{Environment.NewLine}2021-03-16,3.5505,6.4485{Environment.NewLine}");
    }
  }
}