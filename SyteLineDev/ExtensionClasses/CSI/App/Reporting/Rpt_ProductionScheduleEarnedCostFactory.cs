//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ProductionScheduleEarnedCostFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ProductionScheduleEarnedCostFactory
	{
		public IRpt_ProductionScheduleEarnedCost Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ProductionScheduleEarnedCost = new Reporting.Rpt_ProductionScheduleEarnedCost(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ProductionScheduleEarnedCostExt = timerfactory.Create<Reporting.IRpt_ProductionScheduleEarnedCost>(_Rpt_ProductionScheduleEarnedCost);
			
			return iRpt_ProductionScheduleEarnedCostExt;
		}
	}
}
