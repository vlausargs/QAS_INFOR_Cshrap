//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBPayableTrackerLineFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBPayableTrackerLineFactory
	{
		public ICLM_ESBPayableTrackerLine Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBPayableTrackerLine = new BusInterface.CLM_ESBPayableTrackerLine(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBPayableTrackerLineExt = timerfactory.Create<BusInterface.ICLM_ESBPayableTrackerLine>(_CLM_ESBPayableTrackerLine);
			
			return iCLM_ESBPayableTrackerLineExt;
		}
	}
}
