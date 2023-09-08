//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBTransferHeaderFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBTransferHeaderFactory
	{
		public ICLM_ESBTransferHeader Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBTransferHeader = new BusInterface.CLM_ESBTransferHeader(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBTransferHeaderExt = timerfactory.Create<BusInterface.ICLM_ESBTransferHeader>(_CLM_ESBTransferHeader);
			
			return iCLM_ESBTransferHeaderExt;
		}
	}
}
