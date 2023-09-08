//PROJECT NAME: Reporting
//CLASS NAME: RPT_OrderCostFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class RPT_OrderCostFactory
	{
		public IRPT_OrderCost Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _RPT_OrderCost = new Reporting.RPT_OrderCost(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRPT_OrderCostExt = timerfactory.Create<Reporting.IRPT_OrderCost>(_RPT_OrderCost);
			
			return iRPT_OrderCostExt;
		}
	}
}
