//PROJECT NAME: Finance
//CLASS NAME: CLM_FinStmtPreviewFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Finance
{
	public class CLM_FinStmtPreviewFactory
	{
		public ICLM_FinStmtPreview Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_FinStmtPreview = new Finance.CLM_FinStmtPreview(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_FinStmtPreviewExt = timerfactory.Create<Finance.ICLM_FinStmtPreview>(_CLM_FinStmtPreview);
			
			return iCLM_FinStmtPreviewExt;
		}
	}
}
