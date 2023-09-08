//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSLLoadBackflushFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSLLoadBackflushFactory
	{
		public ICLM_FTSLLoadBackflush Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_FTSLLoadBackflush = new Logistics.WarehouseMobility.CLM_FTSLLoadBackflush(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_FTSLLoadBackflushExt = timerfactory.Create<Logistics.WarehouseMobility.ICLM_FTSLLoadBackflush>(_CLM_FTSLLoadBackflush);
			
			return iCLM_FTSLLoadBackflushExt;
		}
	}
}
