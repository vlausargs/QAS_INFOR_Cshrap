//PROJECT NAME: Logistics
//CLASS NAME: FTSLItemPackageSelectFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLItemPackageSelectFactory
	{
		public IFTSLItemPackageSelect Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _FTSLItemPackageSelect = new Logistics.WarehouseMobility.FTSLItemPackageSelect(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLItemPackageSelectExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLItemPackageSelect>(_FTSLItemPackageSelect);
			
			return iFTSLItemPackageSelectExt;
		}
	}
}
