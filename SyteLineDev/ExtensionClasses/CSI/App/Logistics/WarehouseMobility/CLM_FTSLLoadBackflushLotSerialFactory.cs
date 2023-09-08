//PROJECT NAME: Logistics
//CLASS NAME: CLM_FTSLLoadBackflushLotSerialFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class CLM_FTSLLoadBackflushLotSerialFactory
	{
		public ICLM_FTSLLoadBackflushLotSerial Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_FTSLLoadBackflushLotSerial = new Logistics.WarehouseMobility.CLM_FTSLLoadBackflushLotSerial(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_FTSLLoadBackflushLotSerialExt = timerfactory.Create<Logistics.WarehouseMobility.ICLM_FTSLLoadBackflushLotSerial>(_CLM_FTSLLoadBackflushLotSerial);
			
			return iCLM_FTSLLoadBackflushLotSerialExt;
		}
	}
}
