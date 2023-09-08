//PROJECT NAME: Logistics
//CLASS NAME: FTSLItemCountVerifyFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLItemCountVerifyFactory
	{
		public IFTSLItemCountVerify Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _FTSLItemCountVerify = new Logistics.WarehouseMobility.FTSLItemCountVerify(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLItemCountVerifyExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLItemCountVerify>(_FTSLItemCountVerify);
			
			return iFTSLItemCountVerifyExt;
		}
	}
}
