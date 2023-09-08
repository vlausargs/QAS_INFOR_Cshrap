//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ProductSalesAnalysisFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ProductSalesAnalysisFactory
	{
		public IRpt_ProductSalesAnalysis Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ProductSalesAnalysis = new Reporting.Rpt_ProductSalesAnalysis(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ProductSalesAnalysisExt = timerfactory.Create<Reporting.IRpt_ProductSalesAnalysis>(_Rpt_ProductSalesAnalysis);
			
			return iRpt_ProductSalesAnalysisExt;
		}
	}
}
