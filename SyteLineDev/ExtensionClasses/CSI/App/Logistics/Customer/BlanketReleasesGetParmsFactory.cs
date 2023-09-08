//PROJECT NAME: CSICustomer
//CLASS NAME: BlanketReleasesGetParmsFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class BlanketReleasesGetParmsFactory
    {
        public IBlanketReleasesGetParms Create(IApplicationDB appDB)
        {
            var _BlanketReleasesGetParms = new BlanketReleasesGetParms(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iBlanketReleasesGetParmsExt = timerfactory.Create<IBlanketReleasesGetParms>(_BlanketReleasesGetParms);

            return iBlanketReleasesGetParmsExt;
        }
    }
}
