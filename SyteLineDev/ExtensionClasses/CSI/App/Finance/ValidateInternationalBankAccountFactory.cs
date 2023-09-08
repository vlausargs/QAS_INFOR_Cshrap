//PROJECT NAME: CSIFinance
//CLASS NAME: ValidateInternationalBankAccountFactory.cs

using CSI.MG;

namespace CSI.Finance
{
    public class ValidateInternationalBankAccountFactory
    {
        public IValidateInternationalBankAccount Create(IApplicationDB appDB)
        {
            var _ValidateInternationalBankAccount = new ValidateInternationalBankAccount(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSLBankHdrsExt = timerfactory.Create<IValidateInternationalBankAccount>(_ValidateInternationalBankAccount);

            return iSLBankHdrsExt;
        }
    }
}
