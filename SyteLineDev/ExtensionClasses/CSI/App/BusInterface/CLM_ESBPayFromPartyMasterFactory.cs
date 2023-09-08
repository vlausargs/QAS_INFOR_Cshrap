//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBPayFromPartyMasterFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBPayFromPartyMasterFactory
	{
		public ICLM_ESBPayFromPartyMaster Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBPayFromPartyMaster = new BusInterface.CLM_ESBPayFromPartyMaster(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBPayFromPartyMasterExt = timerfactory.Create<BusInterface.ICLM_ESBPayFromPartyMaster>(_CLM_ESBPayFromPartyMaster);
			
			return iCLM_ESBPayFromPartyMasterExt;
		}
	}
}
