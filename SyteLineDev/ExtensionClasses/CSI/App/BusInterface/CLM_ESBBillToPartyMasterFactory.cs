//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBBillToPartyMasterFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBBillToPartyMasterFactory
	{
		public ICLM_ESBBillToPartyMaster Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBBillToPartyMaster = new BusInterface.CLM_ESBBillToPartyMaster(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBBillToPartyMasterExt = timerfactory.Create<BusInterface.ICLM_ESBBillToPartyMaster>(_CLM_ESBBillToPartyMaster);
			
			return iCLM_ESBBillToPartyMasterExt;
		}
	}
}
