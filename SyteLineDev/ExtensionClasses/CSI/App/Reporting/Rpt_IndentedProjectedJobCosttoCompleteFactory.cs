//PROJECT NAME: Reporting
//CLASS NAME: Rpt_IndentedProjectedJobCosttoCompleteFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_IndentedProjectedJobCosttoCompleteFactory
	{
		public IRpt_IndentedProjectedJobCosttoComplete Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_IndentedProjectedJobCosttoComplete = new Reporting.Rpt_IndentedProjectedJobCosttoComplete(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_IndentedProjectedJobCosttoCompleteExt = timerfactory.Create<Reporting.IRpt_IndentedProjectedJobCosttoComplete>(_Rpt_IndentedProjectedJobCosttoComplete);
			
			return iRpt_IndentedProjectedJobCosttoCompleteExt;
		}
	}
}
