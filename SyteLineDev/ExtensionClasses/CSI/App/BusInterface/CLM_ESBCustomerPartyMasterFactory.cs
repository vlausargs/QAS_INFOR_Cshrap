//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBCustomerPartyMasterFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBCustomerPartyMasterFactory
	{
		public ICLM_ESBCustomerPartyMaster Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBCustomerPartyMaster = new BusInterface.CLM_ESBCustomerPartyMaster(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBCustomerPartyMasterExt = timerfactory.Create<BusInterface.ICLM_ESBCustomerPartyMaster>(_CLM_ESBCustomerPartyMaster);
			
			return iCLM_ESBCustomerPartyMasterExt;
		}
	}
}
