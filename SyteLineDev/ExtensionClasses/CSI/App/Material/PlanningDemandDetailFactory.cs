//PROJECT NAME: Material
//CLASS NAME: PlanningDemandDetailFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;
using CSI.Data.Functions;
using CSI.Data.Utilities;

namespace CSI.Material
{
	public class PlanningDemandDetailFactory
	{
		public IPlanningDemandDetail Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var sQLExpressionExecutor = new SQLExpressionExecutorFactory().Create(appDB, parameterProvider);
			var dataTableUtil = new DataTableUtil(sQLExpressionExecutor);
			var _PlanningDemandDetail = new Material.PlanningDemandDetail(appDB, dataTableToCollectionLoadResponse, dataTableUtil);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPlanningDemandDetailExt = timerfactory.Create<Material.IPlanningDemandDetail>(_PlanningDemandDetail);
			
			return iPlanningDemandDetailExt;
		}
	}
}
