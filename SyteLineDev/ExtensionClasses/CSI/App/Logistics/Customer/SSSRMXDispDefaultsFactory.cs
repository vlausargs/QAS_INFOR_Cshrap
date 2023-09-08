//PROJECT NAME: CSICustomer
//CLASS NAME: SSSRMXDispDefaultsFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class SSSRMXDispDefaultsFactory
    {
        public ISSSRMXDispDefaults Create(IApplicationDB appDB)
        {
            var _SSSRMXDispDefaults = new Logistics.Customer.SSSRMXDispDefaults(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSRMXDispDefaultsExt = timerfactory.Create<Logistics.Customer.ISSSRMXDispDefaults>(_SSSRMXDispDefaults);

            return iSSSRMXDispDefaultsExt;
        }
    }
}
