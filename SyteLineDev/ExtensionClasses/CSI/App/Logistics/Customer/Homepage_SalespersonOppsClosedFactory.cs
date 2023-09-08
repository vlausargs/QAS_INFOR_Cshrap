//PROJECT NAME: CSICustomer
//CLASS NAME: Homepage_SalespersonOppsClosedFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class Homepage_SalespersonOppsClosedFactory
	{
		public IHomepage_SalespersonOppsClosed Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Homepage_SalespersonOppsClosed = new Logistics.Customer.Homepage_SalespersonOppsClosed(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHomepage_SalespersonOppsClosedExt = timerfactory.Create<Logistics.Customer.IHomepage_SalespersonOppsClosed>(_Homepage_SalespersonOppsClosed);
			
			return iHomepage_SalespersonOppsClosedExt;
		}
	}
}
