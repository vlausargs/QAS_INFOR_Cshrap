//PROJECT NAME: CSICustomer
//CLASS NAME: SSSRMXShipOneFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class SSSRMXShipOneFactory
    {
        public ISSSRMXShipOne Create(IApplicationDB appDB)
        {
            var _SSSRMXShipOne = new Logistics.Customer.SSSRMXShipOne(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSRMXShipOneExt = timerfactory.Create<Logistics.Customer.ISSSRMXShipOne>(_SSSRMXShipOne);

            return iSSSRMXShipOneExt;
        }
    }
}
