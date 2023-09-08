//PROJECT NAME: Logistics
//CLASS NAME: RetransmitEDIShipSchedulesFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Vendor
{
	public class RetransmitEDIShipSchedulesFactory
	{
		public IRetransmitEDIShipSchedules Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _RetransmitEDIShipSchedules = new Logistics.Vendor.RetransmitEDIShipSchedules(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRetransmitEDIShipSchedulesExt = timerfactory.Create<Logistics.Vendor.IRetransmitEDIShipSchedules>(_RetransmitEDIShipSchedules);
			
			return iRetransmitEDIShipSchedulesExt;
		}
	}
}
