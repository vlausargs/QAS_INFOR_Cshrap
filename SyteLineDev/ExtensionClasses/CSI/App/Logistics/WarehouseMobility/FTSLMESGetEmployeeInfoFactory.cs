//PROJECT NAME: Logistics
//CLASS NAME: FTSLMESGetEmployeeInfoFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Logistics.WarehouseMobility
{
	public class FTSLMESGetEmployeeInfoFactory
	{
		public IFTSLMESGetEmployeeInfo Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _FTSLMESGetEmployeeInfo = new Logistics.WarehouseMobility.FTSLMESGetEmployeeInfo(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFTSLMESGetEmployeeInfoExt = timerfactory.Create<Logistics.WarehouseMobility.IFTSLMESGetEmployeeInfo>(_FTSLMESGetEmployeeInfo);
			
			return iFTSLMESGetEmployeeInfoExt;
		}
	}
}
