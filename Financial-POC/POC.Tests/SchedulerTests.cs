namespace POC.Tests
{
  using System;
  using System.Collections.Generic;
  using NUnit.Framework;

  public class SchedulerTests
  {
    private List<string[]> data;

    public SchedulerTests()
    {
      var db = new FundDayInfoDB("./data/fakeData.csv");
      db.InitDB();
      this.data = db.Data;
    }

    [Test]
    public void GetIndexOfDate_WhenExists_ShouldReturnIndex()
    {
      var schedular = new Scheduler(this.data, 7);
      var i1 = schedular.GetIndexOfDate("2021-04-12");
      var i2 = schedular.GetIndexOfDate("2021-04-07");

      Assert.AreEqual(2, i1);
      Assert.AreEqual(5, i2);
    }

    [Test]
    public void GetIndexOfDate_WhenNotExists_ShouldReturnMinus1()
    {
      var schedular = new Scheduler(this.data, 7);
      var i1 = schedular.GetIndexOfDate("2021-04-16");

      Assert.AreEqual(-1, i1);
    }

    [Test]
    public void GetIndexOfDate_WhenInvalidDateStr_ShouldThrowException()
    {
      var schedular = new Scheduler(this.data, 7);
      Assert.Throws<FormatException>(() => schedular.GetIndexOfDate("abc"));
    }

    [Test]
    public void BeginSchedule_WhenInvalidPeriod_ShouldThrowException()
    {
      var schedular = new Scheduler(this.data, 7);
      Assert.Throws<ArgumentException>(() => schedular.BeginSchedule("2021-04-09", "2021-04-14"));
    }

    [Test]
    public void BeginSchedule_WhenNoRecord_ShouldThrowException()
    {
      var schedular = new Scheduler(this.data, 7);
      Assert.Throws<ArgumentException>(() => schedular.BeginSchedule("2021-04-15", "2021-04-19"));
    }

    [Test]
    public void BeginSchedule_ShouldPublishedCorrectInfo()
    {
      var schedular = new Scheduler(this.data, 7);
      List<FundDayInfo> published = new List<FundDayInfo>();
      schedular.SchedulerPublisher += (FundDayInfo fundDayInfo) => { published.Add(fundDayInfo); };
      schedular.BeginSchedule("2021-03-24", "2021-04-06");
      Assert.AreEqual(2, published.Count);
      Assert.AreEqual(Convert.ToDateTime("2021-03-24"), published[0].Day);
      Assert.AreEqual(3.4990, published[0].NAV);
      Assert.AreEqual(6.3970, published[0].AccNAV);

      Assert.AreEqual(Convert.ToDateTime("2021-04-02"), published[1].Day);
      Assert.AreEqual(3.5242, published[1].NAV);
      Assert.AreEqual(6.5722, published[1].AccNAV);
      
      published.Clear();
      schedular.BeginSchedule("2021-03-24", "2021-04-14");
      Assert.AreEqual(3, published.Count);
    }
  }
}