using System;

namespace POC
{
  public class Buyer
  {
    public void Main(string[] args)
    {
      Console.WriteLine("Hello World!");
    }

    public decimal BuyHowMuch(decimal initAmount, decimal initAccNav, decimal currAccNav){
       return currAccNav/initAccNav*initAmount;
    }
  }
}