//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ResourceGroupLoadProfileSchedulerComparisonFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ResourceGroupLoadProfileSchedulerComparisonFactory
	{
		public IRpt_ResourceGroupLoadProfileSchedulerComparison Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ResourceGroupLoadProfileSchedulerComparison = new Reporting.Rpt_ResourceGroupLoadProfileSchedulerComparison(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ResourceGroupLoadProfileSchedulerComparisonExt = timerfactory.Create<Reporting.IRpt_ResourceGroupLoadProfileSchedulerComparison>(_Rpt_ResourceGroupLoadProfileSchedulerComparison);
			
			return iRpt_ResourceGroupLoadProfileSchedulerComparisonExt;
		}
	}
}
