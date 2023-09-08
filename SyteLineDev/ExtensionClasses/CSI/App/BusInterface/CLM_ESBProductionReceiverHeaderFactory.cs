//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBProductionReceiverHeaderFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBProductionReceiverHeaderFactory
	{
		public ICLM_ESBProductionReceiverHeader Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBProductionReceiverHeader = new BusInterface.CLM_ESBProductionReceiverHeader(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBProductionReceiverHeaderExt = timerfactory.Create<BusInterface.ICLM_ESBProductionReceiverHeader>(_CLM_ESBProductionReceiverHeader);
			
			return iCLM_ESBProductionReceiverHeaderExt;
		}
	}
}
