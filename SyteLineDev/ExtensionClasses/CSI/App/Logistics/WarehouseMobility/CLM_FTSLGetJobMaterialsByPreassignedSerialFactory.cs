//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSLGetJobMaterialsByPreassignedSerialFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSLGetJobMaterialsByPreassignedSerialFactory
	{
		public ICLM_FTSLGetJobMaterialsByPreassignedSerial Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_FTSLGetJobMaterialsByPreassignedSerial = new Logistics.WarehouseMobility.CLM_FTSLGetJobMaterialsByPreassignedSerial(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_FTSLGetJobMaterialsByPreassignedSerialExt = timerfactory.Create<Logistics.WarehouseMobility.ICLM_FTSLGetJobMaterialsByPreassignedSerial>(_CLM_FTSLGetJobMaterialsByPreassignedSerial);
			
			return iCLM_FTSLGetJobMaterialsByPreassignedSerialExt;
		}
	}
}
