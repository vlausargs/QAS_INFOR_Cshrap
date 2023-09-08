//PROJECT NAME: Reporting
//CLASS NAME: Rpt_JobsAffectedByEngineeringChangeNoticesFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_JobsAffectedByEngineeringChangeNoticesFactory
	{
		public IRpt_JobsAffectedByEngineeringChangeNotices Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_JobsAffectedByEngineeringChangeNotices = new Reporting.Rpt_JobsAffectedByEngineeringChangeNotices(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_JobsAffectedByEngineeringChangeNoticesExt = timerfactory.Create<Reporting.IRpt_JobsAffectedByEngineeringChangeNotices>(_Rpt_JobsAffectedByEngineeringChangeNotices);
			
			return iRpt_JobsAffectedByEngineeringChangeNoticesExt;
		}
	}
}
