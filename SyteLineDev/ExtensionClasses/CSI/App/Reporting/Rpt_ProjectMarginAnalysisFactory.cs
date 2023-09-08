//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ProjectMarginAnalysisFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ProjectMarginAnalysisFactory
	{
		public IRpt_ProjectMarginAnalysis Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ProjectMarginAnalysis = new Reporting.Rpt_ProjectMarginAnalysis(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ProjectMarginAnalysisExt = timerfactory.Create<Reporting.IRpt_ProjectMarginAnalysis>(_Rpt_ProjectMarginAnalysis);
			
			return iRpt_ProjectMarginAnalysisExt;
		}
	}
}
