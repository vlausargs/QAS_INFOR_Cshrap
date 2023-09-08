//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBReceivableTrackerHeaderFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBReceivableTrackerHeaderFactory
	{
		public ICLM_ESBReceivableTrackerHeader Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBReceivableTrackerHeader = new BusInterface.CLM_ESBReceivableTrackerHeader(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBReceivableTrackerHeaderExt = timerfactory.Create<BusInterface.ICLM_ESBReceivableTrackerHeader>(_CLM_ESBReceivableTrackerHeader);
			
			return iCLM_ESBReceivableTrackerHeaderExt;
		}
	}
}
