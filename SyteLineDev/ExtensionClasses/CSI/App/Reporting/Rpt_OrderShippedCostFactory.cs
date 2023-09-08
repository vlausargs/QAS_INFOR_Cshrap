//PROJECT NAME: Reporting
//CLASS NAME: Rpt_OrderShippedCostFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_OrderShippedCostFactory
	{
		public IRpt_OrderShippedCost Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_OrderShippedCost = new Reporting.Rpt_OrderShippedCost(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_OrderShippedCostExt = timerfactory.Create<Reporting.IRpt_OrderShippedCost>(_Rpt_OrderShippedCost);
			
			return iRpt_OrderShippedCostExt;
		}
	}
}
