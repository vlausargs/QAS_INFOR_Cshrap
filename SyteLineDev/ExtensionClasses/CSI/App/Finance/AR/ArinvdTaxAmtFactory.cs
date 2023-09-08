//PROJECT NAME: CSICustomer
//CLASS NAME: ArinvdTaxAmtFactory.cs

using CSI.MG;

namespace CSI.Finance.AR
{
    public class ArinvdTaxAmtFactory
    {
        public IArinvdTaxAmt Create(IApplicationDB appDB)
        {
            var _ArinvdTaxAmt = new ArinvdTaxAmt(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iArinvdTaxAmtExt = timerfactory.Create<IArinvdTaxAmt>(_ArinvdTaxAmt);

            return iArinvdTaxAmtExt;
        }
    }
}
