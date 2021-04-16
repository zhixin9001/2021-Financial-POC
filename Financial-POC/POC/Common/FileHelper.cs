namespace FundDayInfo
{
  using System.IO;

  public class FileHelper
  {
    public static void WriteAndSave(string filePath, string content)
    {
      File.WriteAllText(filePath, content);
    }

    public static string Read(string filePath)
    {
      return File.ReadAllText(filePath);
    }
  }
}