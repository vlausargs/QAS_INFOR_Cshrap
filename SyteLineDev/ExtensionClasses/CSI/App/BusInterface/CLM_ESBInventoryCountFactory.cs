//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBInventoryCountFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBInventoryCountFactory
	{
		public ICLM_ESBInventoryCount Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBInventoryCount = new BusInterface.CLM_ESBInventoryCount(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBInventoryCountExt = timerfactory.Create<BusInterface.ICLM_ESBInventoryCount>(_CLM_ESBInventoryCount);
			
			return iCLM_ESBInventoryCountExt;
		}
	}
}
