//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ItembyCustomerSalesAnalysisFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ItembyCustomerSalesAnalysisFactory
	{
		public IRpt_ItembyCustomerSalesAnalysis Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ItembyCustomerSalesAnalysis = new Reporting.Rpt_ItembyCustomerSalesAnalysis(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ItembyCustomerSalesAnalysisExt = timerfactory.Create<Reporting.IRpt_ItembyCustomerSalesAnalysis>(_Rpt_ItembyCustomerSalesAnalysis);
			
			return iRpt_ItembyCustomerSalesAnalysisExt;
		}
	}
}
