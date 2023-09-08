//PROJECT NAME: Reporting
//CLASS NAME: Rpt_WBSPercentCompleteFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_WBSPercentCompleteFactory
	{
		public IRpt_WBSPercentComplete Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_WBSPercentComplete = new Reporting.Rpt_WBSPercentComplete(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_WBSPercentCompleteExt = timerfactory.Create<Reporting.IRpt_WBSPercentComplete>(_Rpt_WBSPercentComplete);
			
			return iRpt_WBSPercentCompleteExt;
		}
	}
}
