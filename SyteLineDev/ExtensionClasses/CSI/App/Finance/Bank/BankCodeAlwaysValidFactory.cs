//PROJECT NAME: CSIFinance
//CLASS NAME: BankCodeAlwaysValidFactory.cs

using CSI.MG;

namespace CSI.Finance.Bank
{
    public class BankCodeAlwaysValidFactory
    {
        public IBankCodeAlwaysValid Create(IApplicationDB appDB)
        {
            var _BankCodeAlwaysValid = new BankCodeAlwaysValid(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSLBankHdrsExt = timerfactory.Create<IBankCodeAlwaysValid>(_BankCodeAlwaysValid);

            return iSLBankHdrsExt;
        }
    }
}

