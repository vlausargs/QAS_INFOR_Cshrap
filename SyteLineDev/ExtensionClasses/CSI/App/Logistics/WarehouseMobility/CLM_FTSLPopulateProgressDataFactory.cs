//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSLPopulateProgressDataFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSLPopulateProgressDataFactory
	{
		public ICLM_FTSLPopulateProgressData Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_FTSLPopulateProgressData = new Logistics.WarehouseMobility.CLM_FTSLPopulateProgressData(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_FTSLPopulateProgressDataExt = timerfactory.Create<Logistics.WarehouseMobility.ICLM_FTSLPopulateProgressData>(_CLM_FTSLPopulateProgressData);
			
			return iCLM_FTSLPopulateProgressDataExt;
		}
	}
}
