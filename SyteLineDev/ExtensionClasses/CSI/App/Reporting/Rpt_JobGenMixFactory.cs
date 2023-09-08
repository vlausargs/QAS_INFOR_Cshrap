//PROJECT NAME: Reporting
//CLASS NAME: Rpt_JobGenMixFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_JobGenMixFactory
	{
		public IRpt_JobGenMix Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_JobGenMix = new Reporting.Rpt_JobGenMix(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_JobGenMixExt = timerfactory.Create<Reporting.IRpt_JobGenMix>(_Rpt_JobGenMix);
			
			return iRpt_JobGenMixExt;
		}
	}
}
