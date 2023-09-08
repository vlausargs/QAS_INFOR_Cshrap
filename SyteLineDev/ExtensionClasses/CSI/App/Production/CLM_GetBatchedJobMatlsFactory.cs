//PROJECT NAME: CSIProduct
//CLASS NAME: CLM_GetBatchedJobMatlsFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production
{
	public class CLM_GetBatchedJobMatlsFactory
	{
		public ICLM_GetBatchedJobMatls Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_GetBatchedJobMatls = new Production.CLM_GetBatchedJobMatls(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_GetBatchedJobMatlsExt = timerfactory.Create<Production.ICLM_GetBatchedJobMatls>(_CLM_GetBatchedJobMatls);
			
			return iCLM_GetBatchedJobMatlsExt;
		}
	}
}
