//PROJECT NAME: Logistics
//CLASS NAME: FetchPreassignedLotsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class FetchPreassignedLotsFactory
	{
		public IFetchPreassignedLots Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _FetchPreassignedLots = new Logistics.Vendor.FetchPreassignedLots(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFetchPreassignedLotsExt = timerfactory.Create<Logistics.Vendor.IFetchPreassignedLots>(_FetchPreassignedLots);
			
			return iFetchPreassignedLotsExt;
		}
	}
}
