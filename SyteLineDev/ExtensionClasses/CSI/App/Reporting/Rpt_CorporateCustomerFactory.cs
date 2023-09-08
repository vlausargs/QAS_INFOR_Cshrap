//PROJECT NAME: Reporting
//CLASS NAME: Rpt_CorporateCustomerFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_CorporateCustomerFactory
	{
		public IRpt_CorporateCustomer Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_CorporateCustomer = new Reporting.Rpt_CorporateCustomer(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_CorporateCustomerExt = timerfactory.Create<Reporting.IRpt_CorporateCustomer>(_Rpt_CorporateCustomer);
			
			return iRpt_CorporateCustomerExt;
		}
	}
}
