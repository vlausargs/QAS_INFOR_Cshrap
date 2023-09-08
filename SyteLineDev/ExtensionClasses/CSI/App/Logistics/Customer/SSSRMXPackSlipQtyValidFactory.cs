//PROJECT NAME: CSICustomer
//CLASS NAME: SSSRMXPackSlipQtyValidFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class SSSRMXPackSlipQtyValidFactory
    {
        public ISSSRMXPackSlipQtyValid Create(IApplicationDB appDB)
        {
            var _SSSRMXPackSlipQtyValid = new Logistics.Customer.SSSRMXPackSlipQtyValid(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSRMXPackSlipQtyValidExt = timerfactory.Create<Logistics.Customer.ISSSRMXPackSlipQtyValid>(_SSSRMXPackSlipQtyValid);

            return iSSSRMXPackSlipQtyValidExt;
        }
    }
}
