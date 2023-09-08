//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBReceivableTrackerLineFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBReceivableTrackerLineFactory
	{
		public ICLM_ESBReceivableTrackerLine Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBReceivableTrackerLine = new BusInterface.CLM_ESBReceivableTrackerLine(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBReceivableTrackerLineExt = timerfactory.Create<BusInterface.ICLM_ESBReceivableTrackerLine>(_CLM_ESBReceivableTrackerLine);
			
			return iCLM_ESBReceivableTrackerLineExt;
		}
	}
}
