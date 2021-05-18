using System.Linq;

namespace POC
{
    public class LadderSeller : Seller
    {
        public int SelleTimes { get; private set; }

        public LadderSeller(Transaction transaction, decimal sellThreshold) : base(transaction, sellThreshold)
        {
        }

        public override void TimeToHandle(FundDayInfo fundDayInfo)
        {
            foreach (var record in transaction.Records)
            {
                record.CurrentValue = GetCurrentValue(record.FundShares, fundDayInfo.NAV);
            }

            var notSelledInput = CalcNotSelledInput();
            var notSelledOutput = CalcNotSelledOutput();
            var ownRate = CalcOwnRate(notSelledInput, notSelledOutput);
            if (ownRate > base.SellThreshold)
            {
                Sell(fundDayInfo, notSelledOutput - notSelledInput);
            }
        }


        public decimal CalcNotSelledInput()
        {
            return base.transaction.Records.FindAll(a => !a.SelledDate.HasValue).Sum(a => a.Amount);
        }

        public decimal CalcNotSelledOutput()
        {
            return base.transaction.Records.FindAll(a => !a.SelledDate.HasValue).Sum(a => a.CurrentValue);
        }

        public decimal CalcOwnRate(decimal input, decimal output)
        {
            if (output <= 0)
            {
                return 0;
            }
            return decimal.Round((output - input) * 100 / input, 2);
        }

        public void Sell(FundDayInfo fundDayInfo, decimal needSellAmount)
        {
            if (needSellAmount <= 0)
            {
                return;
            }
            var selled = 0m;
            foreach (var record in transaction.Records.FindAll(a => !a.SelledDate.HasValue))
            {
                record.SelledDate = fundDayInfo.Day;
                selled +=record.Amount;

                if (selled >= needSellAmount)
                {
                    break;
                }
            }
        }
    }
}