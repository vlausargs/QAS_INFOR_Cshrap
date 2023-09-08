//PROJECT NAME: CSICustomer
//CLASS NAME: SSSRMXShipDeleteFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class SSSRMXShipDeleteFactory
    {
        public ISSSRMXShipDelete Create(IApplicationDB appDB)
        {
            var _SSSRMXShipDelete = new Logistics.Customer.SSSRMXShipDelete(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSRMXShipDeleteExt = timerfactory.Create<Logistics.Customer.ISSSRMXShipDelete>(_SSSRMXShipDelete);

            return iSSSRMXShipDeleteExt;
        }
    }
}
