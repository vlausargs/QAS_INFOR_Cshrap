//PROJECT NAME: CSICustomer
//CLASS NAME: ArinvdGetTaxAcctFactory.cs

using CSI.MG;

namespace CSI.Finance.AR
{
    public class ArinvdGetTaxAcctFactory
    {
        public IArinvdGetTaxAcct Create(IApplicationDB appDB)
        {
            var _ArinvdGetTaxAcct = new ArinvdGetTaxAcct(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iArinvdGetTaxAcctExt = timerfactory.Create<IArinvdGetTaxAcct>(_ArinvdGetTaxAcct);

            return iArinvdGetTaxAcctExt;
        }
    }
}
