//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBAdvanceShipNoticeHdrFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBAdvanceShipNoticeHdrFactory
	{
		public ICLM_ESBAdvanceShipNoticeHdr Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBAdvanceShipNoticeHdr = new BusInterface.CLM_ESBAdvanceShipNoticeHdr(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBAdvanceShipNoticeHdrExt = timerfactory.Create<BusInterface.ICLM_ESBAdvanceShipNoticeHdr>(_CLM_ESBAdvanceShipNoticeHdr);
			
			return iCLM_ESBAdvanceShipNoticeHdrExt;
		}
	}
}
