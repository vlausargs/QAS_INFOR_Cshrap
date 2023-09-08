//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBSupplierPartyMasterFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBSupplierPartyMasterFactory
	{
		public ICLM_ESBSupplierPartyMaster Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBSupplierPartyMaster = new BusInterface.CLM_ESBSupplierPartyMaster(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBSupplierPartyMasterExt = timerfactory.Create<BusInterface.ICLM_ESBSupplierPartyMaster>(_CLM_ESBSupplierPartyMaster);
			
			return iCLM_ESBSupplierPartyMasterExt;
		}
	}
}
