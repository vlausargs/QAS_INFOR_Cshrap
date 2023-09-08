//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBAdvanceShipNoticeLineFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBAdvanceShipNoticeLineFactory
	{
		public ICLM_ESBAdvanceShipNoticeLine Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBAdvanceShipNoticeLine = new BusInterface.CLM_ESBAdvanceShipNoticeLine(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBAdvanceShipNoticeLineExt = timerfactory.Create<BusInterface.ICLM_ESBAdvanceShipNoticeLine>(_CLM_ESBAdvanceShipNoticeLine);
			
			return iCLM_ESBAdvanceShipNoticeLineExt;
		}
	}
}
