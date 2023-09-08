//PROJECT NAME: Logistics
//CLASS NAME: CLM_ListEstimatedChargFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class CLM_ListEstimatedChargFactory
	{
		public ICLM_ListEstimatedCharg Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ListEstimatedCharg = new Logistics.Customer.CLM_ListEstimatedCharg(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ListEstimatedChargExt = timerfactory.Create<Logistics.Customer.ICLM_ListEstimatedCharg>(_CLM_ListEstimatedCharg);
			
			return iCLM_ListEstimatedChargExt;
		}
	}
}
