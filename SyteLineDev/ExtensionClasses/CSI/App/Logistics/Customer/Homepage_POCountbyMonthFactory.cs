//PROJECT NAME: CSICustomer
//CLASS NAME: Homepage_POCountbyMonthFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class Homepage_POCountbyMonthFactory
	{
		public IHomepage_POCountbyMonth Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Homepage_POCountbyMonth = new Logistics.Customer.Homepage_POCountbyMonth(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHomepage_POCountbyMonthExt = timerfactory.Create<Logistics.Customer.IHomepage_POCountbyMonth>(_Homepage_POCountbyMonth);
			
			return iHomepage_POCountbyMonthExt;
		}
	}
}
