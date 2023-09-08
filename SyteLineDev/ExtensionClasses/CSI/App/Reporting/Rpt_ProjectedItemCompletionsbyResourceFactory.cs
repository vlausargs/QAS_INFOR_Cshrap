//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ProjectedItemCompletionsbyResourceFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ProjectedItemCompletionsbyResourceFactory
	{
		public IRpt_ProjectedItemCompletionsbyResource Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ProjectedItemCompletionsbyResource = new Reporting.Rpt_ProjectedItemCompletionsbyResource(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ProjectedItemCompletionsbyResourceExt = timerfactory.Create<Reporting.IRpt_ProjectedItemCompletionsbyResource>(_Rpt_ProjectedItemCompletionsbyResource);
			
			return iRpt_ProjectedItemCompletionsbyResourceExt;
		}
	}
}
