//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ItemCustomerSalesPersonSalesAnalysisFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ItemCustomerSalesPersonSalesAnalysisFactory
	{
		public IRpt_ItemCustomerSalesPersonSalesAnalysis Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ItemCustomerSalesPersonSalesAnalysis = new Reporting.Rpt_ItemCustomerSalesPersonSalesAnalysis(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ItemCustomerSalesPersonSalesAnalysisExt = timerfactory.Create<Reporting.IRpt_ItemCustomerSalesPersonSalesAnalysis>(_Rpt_ItemCustomerSalesPersonSalesAnalysis);
			
			return iRpt_ItemCustomerSalesPersonSalesAnalysisExt;
		}
	}
}
