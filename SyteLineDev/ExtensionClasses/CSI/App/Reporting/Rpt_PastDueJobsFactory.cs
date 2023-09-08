//PROJECT NAME: Reporting
//CLASS NAME: Rpt_PastDueJobsFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_PastDueJobsFactory
	{
		public IRpt_PastDueJobs Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_PastDueJobs = new Reporting.Rpt_PastDueJobs(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_PastDueJobsExt = timerfactory.Create<Reporting.IRpt_PastDueJobs>(_Rpt_PastDueJobs);
			
			return iRpt_PastDueJobsExt;
		}
	}
}
