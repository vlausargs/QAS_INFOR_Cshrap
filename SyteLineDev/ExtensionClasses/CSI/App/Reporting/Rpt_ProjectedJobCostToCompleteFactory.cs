//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ProjectedJobCostToCompleteFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ProjectedJobCostToCompleteFactory
	{
		public IRpt_ProjectedJobCostToComplete Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ProjectedJobCostToComplete = new Reporting.Rpt_ProjectedJobCostToComplete(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ProjectedJobCostToCompleteExt = timerfactory.Create<Reporting.IRpt_ProjectedJobCostToComplete>(_Rpt_ProjectedJobCostToComplete);
			
			return iRpt_ProjectedJobCostToCompleteExt;
		}
	}
}
