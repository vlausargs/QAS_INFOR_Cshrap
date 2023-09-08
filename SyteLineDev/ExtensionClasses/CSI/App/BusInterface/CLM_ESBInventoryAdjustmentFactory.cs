//PROJECT NAME: BusInterface
//CLASS NAME: CLM_ESBInventoryAdjustmentFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.BusInterface
{
	public class CLM_ESBInventoryAdjustmentFactory
	{
		public ICLM_ESBInventoryAdjustment Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ESBInventoryAdjustment = new BusInterface.CLM_ESBInventoryAdjustment(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ESBInventoryAdjustmentExt = timerfactory.Create<BusInterface.ICLM_ESBInventoryAdjustment>(_CLM_ESBInventoryAdjustment);
			
			return iCLM_ESBInventoryAdjustmentExt;
		}
	}
}
