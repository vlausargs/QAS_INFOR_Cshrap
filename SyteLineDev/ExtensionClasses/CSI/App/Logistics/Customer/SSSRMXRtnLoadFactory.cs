//PROJECT NAME: CSICustomer
//CLASS NAME: SSSRMXRtnLoadFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class SSSRMXRtnLoadFactory
    {
        public ISSSRMXRtnLoad Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _SSSRMXRtnLoad = new Logistics.Customer.SSSRMXRtnLoad(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSRMXRtnLoadExt = timerfactory.Create<Logistics.Customer.ISSSRMXRtnLoad>(_SSSRMXRtnLoad);

            return iSSSRMXRtnLoadExt;
        }
    }
}
