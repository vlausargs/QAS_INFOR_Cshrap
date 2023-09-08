//PROJECT NAME: CSIMaterial
//CLASS NAME: CLM_SerialsForTransactionsFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class CLM_SerialsForTransactionsFactory
	{
		public ICLM_SerialsForTransactions Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_SerialsForTransactions = new Material.CLM_SerialsForTransactions(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_SerialsForTransactionsExt = timerfactory.Create<Material.ICLM_SerialsForTransactions>(_CLM_SerialsForTransactions);
			
			return iCLM_SerialsForTransactionsExt;
		}
	}
}
