//PROJECT NAME: Logistics
//CLASS NAME: PurgeEDIShipSchedulesFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class PurgeEDIShipSchedulesFactory
	{
		public IPurgeEDIShipSchedules Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PurgeEDIShipSchedules = new Logistics.Customer.PurgeEDIShipSchedules(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPurgeEDIShipSchedulesExt = timerfactory.Create<Logistics.Customer.IPurgeEDIShipSchedules>(_PurgeEDIShipSchedules);
			
			return iPurgeEDIShipSchedulesExt;
		}
	}
}
