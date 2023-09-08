//PROJECT NAME: CSICustomer
//CLASS NAME: SSSRMXGetDefRMAWhseLocFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class SSSRMXGetDefRMAWhseLocFactory
    {
        public ISSSRMXGetDefRMAWhseLoc Create(IApplicationDB appDB)
        {
            var _SSSRMXGetDefRMAWhseLoc = new Logistics.Customer.SSSRMXGetDefRMAWhseLoc(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSRMXGetDefRMAWhseLocExt = timerfactory.Create<Logistics.Customer.ISSSRMXGetDefRMAWhseLoc>(_SSSRMXGetDefRMAWhseLoc);

            return iSSSRMXGetDefRMAWhseLocExt;
        }
    }
}
