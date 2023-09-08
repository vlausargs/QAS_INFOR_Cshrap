//PROJECT NAME: Logistics
//CLASS NAME: FTSLGetProjectTaksMatlFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLGetProjectTaksMatlFactory
	{
		public IFTSLGetProjectTaksMatl Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _FTSLGetProjectTaksMatl = new Logistics.WarehouseMobility.FTSLGetProjectTaksMatl(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLGetProjectTaksMatlExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLGetProjectTaksMatl>(_FTSLGetProjectTaksMatl);
			
			return iFTSLGetProjectTaksMatlExt;
		}
	}
}
