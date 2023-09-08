//PROJECT NAME: Logistics
//CLASS NAME: DemandingPoSourceCoSyncFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class DemandingPoSourceCoSyncFactory
	{
		public IDemandingPoSourceCoSync Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _DemandingPoSourceCoSync = new Logistics.Vendor.DemandingPoSourceCoSync(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDemandingPoSourceCoSyncExt = timerfactory.Create<Logistics.Vendor.IDemandingPoSourceCoSync>(_DemandingPoSourceCoSync);
			
			return iDemandingPoSourceCoSyncExt;
		}
	}
}
