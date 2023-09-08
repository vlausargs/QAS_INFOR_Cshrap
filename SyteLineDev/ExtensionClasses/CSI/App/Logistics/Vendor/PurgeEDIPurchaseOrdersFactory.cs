//PROJECT NAME: Logistics
//CLASS NAME: PurgeEDIPurchaseOrdersFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class PurgeEDIPurchaseOrdersFactory
	{
		public IPurgeEDIPurchaseOrders Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PurgeEDIPurchaseOrders = new Logistics.Vendor.PurgeEDIPurchaseOrders(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPurgeEDIPurchaseOrdersExt = timerfactory.Create<Logistics.Vendor.IPurgeEDIPurchaseOrders>(_PurgeEDIPurchaseOrders);
			
			return iPurgeEDIPurchaseOrdersExt;
		}
	}
}
