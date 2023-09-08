//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ItemSalespersonSalesAnalysisFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ItemSalespersonSalesAnalysisFactory
	{
		public IRpt_ItemSalespersonSalesAnalysis Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ItemSalespersonSalesAnalysis = new Reporting.Rpt_ItemSalespersonSalesAnalysis(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ItemSalespersonSalesAnalysisExt = timerfactory.Create<Reporting.IRpt_ItemSalespersonSalesAnalysis>(_Rpt_ItemSalespersonSalesAnalysis);
			
			return iRpt_ItemSalespersonSalesAnalysisExt;
		}
	}
}
