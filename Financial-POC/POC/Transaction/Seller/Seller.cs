using System;

namespace POC
{
    public abstract class Seller
    {
        protected Transaction transaction;
        protected decimal SellThreshold;

        public Seller(Transaction transaction, decimal sellThreshold)
        {
            this.transaction = transaction;
            this.SellThreshold = sellThreshold;
        }

        public abstract void TimeToHandle(FundDayInfo fundDayInfo);

        public decimal GetCurrentValue(decimal fundShares, decimal currentNav)
        {
            return decimal.Round(fundShares * currentNav, 2);
        }

        public decimal GetRateOfReturn(decimal originAmount, decimal currentValue)
        {
            return decimal.Round((currentValue - originAmount) / originAmount, 2);
        }
    }
}