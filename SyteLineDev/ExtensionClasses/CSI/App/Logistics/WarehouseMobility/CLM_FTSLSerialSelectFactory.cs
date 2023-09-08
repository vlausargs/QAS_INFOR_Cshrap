//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSLSerialSelectFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSLSerialSelectFactory
	{
		public ICLM_FTSLSerialSelect Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_FTSLSerialSelect = new Logistics.WarehouseMobility.CLM_FTSLSerialSelect(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_FTSLSerialSelectExt = timerfactory.Create<Logistics.WarehouseMobility.ICLM_FTSLSerialSelect>(_CLM_FTSLSerialSelect);
			
			return iCLM_FTSLSerialSelectExt;
		}
	}
}
