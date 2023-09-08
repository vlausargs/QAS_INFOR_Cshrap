//PROJECT NAME: Logistics
//CLASS NAME: FTSLPreAssignedSnSelectFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLPreAssignedSnSelectFactory
	{
		public IFTSLPreAssignedSnSelect Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _FTSLPreAssignedSnSelect = new Logistics.WarehouseMobility.FTSLPreAssignedSnSelect(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLPreAssignedSnSelectExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLPreAssignedSnSelect>(_FTSLPreAssignedSnSelect);
			
			return iFTSLPreAssignedSnSelectExt;
		}
	}
}
