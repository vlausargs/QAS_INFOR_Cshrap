//PROJECT NAME: CSIFinance
//CLASS NAME: PayrollValidateBankFactory.cs

using CSI.MG;

namespace CSI.Finance
{
    public class PayrollValidateBankFactory
    {
        public IPayrollValidateBank Create(IApplicationDB appDB)
        {
            var _PayrollValidateBank = new PayrollValidateBank(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSLBankHdrsExt = timerfactory.Create<IPayrollValidateBank>(_PayrollValidateBank);

            return iSLBankHdrsExt;
        }
    }
}
