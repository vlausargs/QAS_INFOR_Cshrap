//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBReplDocumentExtPivotFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBReplDocumentExtPivotFactory
	{
		public ICLM_ESBReplDocumentExtPivot Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBReplDocumentExtPivot = new BusInterface.CLM_ESBReplDocumentExtPivot(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBReplDocumentExtPivotExt = timerfactory.Create<BusInterface.ICLM_ESBReplDocumentExtPivot>(_CLM_ESBReplDocumentExtPivot);
			
			return iCLM_ESBReplDocumentExtPivotExt;
		}
	}
}
