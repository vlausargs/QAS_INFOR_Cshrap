//PROJECT NAME: CSICustomer
//CLASS NAME: SSSRMXShipRevOneFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class SSSRMXShipRevOneFactory
    {
        public ISSSRMXShipRevOne Create(IApplicationDB appDB)
        {
            var _SSSRMXShipRevOne = new Logistics.Customer.SSSRMXShipRevOne(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSRMXShipRevOneExt = timerfactory.Create<Logistics.Customer.ISSSRMXShipRevOne>(_SSSRMXShipRevOne);

            return iSSSRMXShipRevOneExt;
        }
    }
}
