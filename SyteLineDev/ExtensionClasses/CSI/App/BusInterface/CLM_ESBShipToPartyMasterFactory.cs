//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBShipToPartyMasterFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBShipToPartyMasterFactory
	{
		public ICLM_ESBShipToPartyMaster Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBShipToPartyMaster = new BusInterface.CLM_ESBShipToPartyMaster(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBShipToPartyMasterExt = timerfactory.Create<BusInterface.ICLM_ESBShipToPartyMaster>(_CLM_ESBShipToPartyMaster);
			
			return iCLM_ESBShipToPartyMasterExt;
		}
	}
}
