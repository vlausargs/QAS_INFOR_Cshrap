//PROJECT NAME: CSIFinance
//CLASS NAME: GetDefaultBankCodeFactory.cs

using CSI.MG;

namespace CSI.Finance
{
    public class GetDefaultBankCodeFactory
    {
        public IGetDefaultBankCode Create(IApplicationDB appDB)
        {
            var _GetDefaultBankCode = new GetDefaultBankCode(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSLBankHdrsExt = timerfactory.Create<IGetDefaultBankCode>(_GetDefaultBankCode);

            return iSLBankHdrsExt;
        }
    }
}