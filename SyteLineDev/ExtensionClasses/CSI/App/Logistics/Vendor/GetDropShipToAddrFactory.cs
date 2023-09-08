//PROJECT NAME: Logistics
//CLASS NAME: GetDropShipToAddrFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class GetDropShipToAddrFactory
	{
		public IGetDropShipToAddr Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetDropShipToAddr = new Logistics.Vendor.GetDropShipToAddr(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetDropShipToAddrExt = timerfactory.Create<Logistics.Vendor.IGetDropShipToAddr>(_GetDropShipToAddr);
			
			return iGetDropShipToAddrExt;
		}
	}
}
