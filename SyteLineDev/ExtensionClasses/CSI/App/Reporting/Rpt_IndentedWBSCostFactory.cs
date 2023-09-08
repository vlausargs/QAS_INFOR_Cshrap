//PROJECT NAME: Reporting
//CLASS NAME: Rpt_IndentedWBSCostFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_IndentedWBSCostFactory
	{
		public IRpt_IndentedWBSCost Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_IndentedWBSCost = new Reporting.Rpt_IndentedWBSCost(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_IndentedWBSCostExt = timerfactory.Create<Reporting.IRpt_IndentedWBSCost>(_Rpt_IndentedWBSCost);
			
			return iRpt_IndentedWBSCostExt;
		}
	}
}
