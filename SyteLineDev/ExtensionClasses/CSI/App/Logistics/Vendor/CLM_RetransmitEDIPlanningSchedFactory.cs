//PROJECT NAME: Logistics
//CLASS NAME: RetransmitEDIPlanningSchedFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Vendor
{
	public class CLM_RetransmitEDIPlanningSchedFactory
	{
		public ICLM_RetransmitEDIPlanningSched Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _RetransmitEDIPlanningSched = new Logistics.Vendor.CLM_RetransmitEDIPlanningSched(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRetransmitEDIPlanningSchedExt = timerfactory.Create<Logistics.Vendor.ICLM_RetransmitEDIPlanningSched>(_RetransmitEDIPlanningSched);
			
			return iRetransmitEDIPlanningSchedExt;
		}
	}
}
