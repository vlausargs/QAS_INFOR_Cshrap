//PROJECT NAME: CSICustomer
//CLASS NAME: SSSRMXRtnOneFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class SSSRMXRtnOneFactory
    {
        public ISSSRMXRtnOne Create(IApplicationDB appDB)
        {
            var _SSSRMXRtnOne = new Logistics.Customer.SSSRMXRtnOne(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSRMXRtnOneExt = timerfactory.Create<Logistics.Customer.ISSSRMXRtnOne>(_SSSRMXRtnOne);

            return iSSSRMXRtnOneExt;
        }
    }
}
