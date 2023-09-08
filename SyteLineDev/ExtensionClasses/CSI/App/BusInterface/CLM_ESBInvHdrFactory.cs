//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBInvHdrFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBInvHdrFactory
	{
		public ICLM_ESBInvHdr Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBInvHdr = new BusInterface.CLM_ESBInvHdr(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBInvHdrExt = timerfactory.Create<BusInterface.ICLM_ESBInvHdr>(_CLM_ESBInvHdr);
			
			return iCLM_ESBInvHdrExt;
		}
	}
}
