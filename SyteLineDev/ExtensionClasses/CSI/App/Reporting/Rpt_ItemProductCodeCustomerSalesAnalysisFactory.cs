//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ItemProductCodeCustomerSalesAnalysisFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ItemProductCodeCustomerSalesAnalysisFactory
	{
		public IRpt_ItemProductCodeCustomerSalesAnalysis Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ItemProductCodeCustomerSalesAnalysis = new Reporting.Rpt_ItemProductCodeCustomerSalesAnalysis(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ItemProductCodeCustomerSalesAnalysisExt = timerfactory.Create<Reporting.IRpt_ItemProductCodeCustomerSalesAnalysis>(_Rpt_ItemProductCodeCustomerSalesAnalysis);
			
			return iRpt_ItemProductCodeCustomerSalesAnalysisExt;
		}
	}
}
