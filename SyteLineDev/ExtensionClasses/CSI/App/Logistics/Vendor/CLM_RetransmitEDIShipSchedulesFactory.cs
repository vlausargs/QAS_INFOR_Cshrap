//PROJECT NAME: Logistics
//CLASS NAME: RetransmitEDIShipSchedulesFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Vendor
{
	public class CLM_RetransmitEDIShipSchedulesFactory
	{
		public ICLM_RetransmitEDIShipSchedules Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _RetransmitEDIShipSchedules = new Logistics.Vendor.CLM_RetransmitEDIShipSchedules(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRetransmitEDIShipSchedulesExt = timerfactory.Create<Logistics.Vendor.ICLM_RetransmitEDIShipSchedules>(_RetransmitEDIShipSchedules);
			
			return iRetransmitEDIShipSchedulesExt;
		}
	}
}
