//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBPurchaseOrderBlanketLineFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBPurchaseOrderBlanketLineFactory
	{
		public ICLM_ESBPurchaseOrderBlanketLine Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBPurchaseOrderBlanketLine = new BusInterface.CLM_ESBPurchaseOrderBlanketLine(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBPurchaseOrderBlanketLineExt = timerfactory.Create<BusInterface.ICLM_ESBPurchaseOrderBlanketLine>(_CLM_ESBPurchaseOrderBlanketLine);
			
			return iCLM_ESBPurchaseOrderBlanketLineExt;
		}
	}
}
