//PROJECT NAME: Reporting
//CLASS NAME: Rpt_CustomerByItemSalesAnalysisFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_CustomerByItemSalesAnalysisFactory
	{
		public IRpt_CustomerByItemSalesAnalysis Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_CustomerByItemSalesAnalysis = new Reporting.Rpt_CustomerByItemSalesAnalysis(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_CustomerByItemSalesAnalysisExt = timerfactory.Create<Reporting.IRpt_CustomerByItemSalesAnalysis>(_Rpt_CustomerByItemSalesAnalysis);
			
			return iRpt_CustomerByItemSalesAnalysisExt;
		}
	}
}
