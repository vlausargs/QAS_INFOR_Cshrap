//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBPayableTrackerHeaderFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBPayableTrackerHeaderFactory
	{
		public ICLM_ESBPayableTrackerHeader Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBPayableTrackerHeader = new BusInterface.CLM_ESBPayableTrackerHeader(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBPayableTrackerHeaderExt = timerfactory.Create<BusInterface.ICLM_ESBPayableTrackerHeader>(_CLM_ESBPayableTrackerHeader);
			
			return iCLM_ESBPayableTrackerHeaderExt;
		}
	}
}
