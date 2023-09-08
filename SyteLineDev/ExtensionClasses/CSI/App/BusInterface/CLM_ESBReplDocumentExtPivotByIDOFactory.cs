//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBReplDocumentExtPivotByIDOFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBReplDocumentExtPivotByIDOFactory
	{
		public ICLM_ESBReplDocumentExtPivotByIDO Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBReplDocumentExtPivotByIDO = new BusInterface.CLM_ESBReplDocumentExtPivotByIDO(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBReplDocumentExtPivotByIDOExt = timerfactory.Create<BusInterface.ICLM_ESBReplDocumentExtPivotByIDO>(_CLM_ESBReplDocumentExtPivotByIDO);
			
			return iCLM_ESBReplDocumentExtPivotByIDOExt;
		}
	}
}
