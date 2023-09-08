//PROJECT NAME: CSICustomer
//CLASS NAME: Homepage_ProjectShippingFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class Homepage_ProjectShippingFactory
	{
		public IHomepage_ProjectShipping Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Homepage_ProjectShipping = new Logistics.Customer.Homepage_ProjectShipping(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHomepage_ProjectShippingExt = timerfactory.Create<Logistics.Customer.IHomepage_ProjectShipping>(_Homepage_ProjectShipping);
			
			return iHomepage_ProjectShippingExt;
		}
	}
}
