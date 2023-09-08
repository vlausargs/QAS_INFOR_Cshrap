//PROJECT NAME: Logistics
//CLASS NAME: FTSLValidServiceLaborFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLValidServiceLaborFactory
	{
		public IFTSLValidServiceLabor Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _FTSLValidServiceLabor = new Logistics.WarehouseMobility.FTSLValidServiceLabor(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLValidServiceLaborExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLValidServiceLabor>(_FTSLValidServiceLabor);
			
			return iFTSLValidServiceLaborExt;
		}
	}
}
