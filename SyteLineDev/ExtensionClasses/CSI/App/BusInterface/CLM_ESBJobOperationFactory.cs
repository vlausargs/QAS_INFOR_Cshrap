//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBJobOperationFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBJobOperationFactory
	{
		public ICLM_ESBJobOperation Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBJobOperation = new BusInterface.CLM_ESBJobOperation(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBJobOperationExt = timerfactory.Create<BusInterface.ICLM_ESBJobOperation>(_CLM_ESBJobOperation);
			
			return iCLM_ESBJobOperationExt;
		}
	}
}
