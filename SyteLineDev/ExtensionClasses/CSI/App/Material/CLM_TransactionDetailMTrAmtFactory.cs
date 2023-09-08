//PROJECT NAME: Material
//CLASS NAME: CLM_TransactionDetailMTrAmtFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Material
{
	public class CLM_TransactionDetailMTrAmtFactory
	{
		public ICLM_TransactionDetailMTrAmt Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_TransactionDetailMTrAmt = new Material.CLM_TransactionDetailMTrAmt(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_TransactionDetailMTrAmtExt = timerfactory.Create<Material.ICLM_TransactionDetailMTrAmt>(_CLM_TransactionDetailMTrAmt);
			
			return iCLM_TransactionDetailMTrAmtExt;
		}
	}
}
