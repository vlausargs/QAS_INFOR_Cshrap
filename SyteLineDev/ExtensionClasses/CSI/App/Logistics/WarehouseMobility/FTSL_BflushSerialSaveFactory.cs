//PROJECT NAME: Logistics
//CLASS NAME: FTSL_BflushSerialSaveFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSL_BflushSerialSaveFactory
	{
		public IFTSL_BflushSerialSave Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _FTSL_BflushSerialSave = new Logistics.WarehouseMobility.FTSL_BflushSerialSave(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSL_BflushSerialSaveExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSL_BflushSerialSave>(_FTSL_BflushSerialSave);
			
			return iFTSL_BflushSerialSaveExt;
		}
	}
}
