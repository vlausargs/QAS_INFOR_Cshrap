//PROJECT NAME: Reporting
//CLASS NAME: Rpt_RollCurrentCosttoStandardCostFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_RollCurrentCosttoStandardCostFactory
	{
		public IRpt_RollCurrentCosttoStandardCost Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_RollCurrentCosttoStandardCost = new Reporting.Rpt_RollCurrentCosttoStandardCost(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_RollCurrentCosttoStandardCostExt = timerfactory.Create<Reporting.IRpt_RollCurrentCosttoStandardCost>(_Rpt_RollCurrentCosttoStandardCost);
			
			return iRpt_RollCurrentCosttoStandardCostExt;
		}
	}
}
