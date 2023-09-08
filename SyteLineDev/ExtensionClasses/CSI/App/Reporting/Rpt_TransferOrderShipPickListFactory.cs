//PROJECT NAME: Reporting
//CLASS NAME: Rpt_TransferOrderShipPickListFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_TransferOrderShipPickListFactory
	{
		public IRpt_TransferOrderShipPickList Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_TransferOrderShipPickList = new Reporting.Rpt_TransferOrderShipPickList(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_TransferOrderShipPickListExt = timerfactory.Create<Reporting.IRpt_TransferOrderShipPickList>(_Rpt_TransferOrderShipPickList);
			
			return iRpt_TransferOrderShipPickListExt;
		}
	}
}
