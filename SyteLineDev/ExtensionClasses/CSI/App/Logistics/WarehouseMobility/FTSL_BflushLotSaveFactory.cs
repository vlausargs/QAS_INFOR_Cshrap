//PROJECT NAME: Logistics
//CLASS NAME: FTSL_BflushLotSaveFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSL_BflushLotSaveFactory
	{
		public IFTSL_BflushLotSave Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _FTSL_BflushLotSave = new Logistics.WarehouseMobility.FTSL_BflushLotSave(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSL_BflushLotSaveExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSL_BflushLotSave>(_FTSL_BflushLotSave);
			
			return iFTSL_BflushLotSaveExt;
		}
	}
}
