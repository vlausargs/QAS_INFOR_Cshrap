//PROJECT NAME: Logistics
//CLASS NAME: GetShipmentTrackingURLFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class GetShipmentTrackingURLFactory
	{
		public IGetShipmentTrackingURL Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetShipmentTrackingURL = new Logistics.Customer.GetShipmentTrackingURL(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetShipmentTrackingURLExt = timerfactory.Create<Logistics.Customer.IGetShipmentTrackingURL>(_GetShipmentTrackingURL);
			
			return iGetShipmentTrackingURLExt;
		}
	}
}
