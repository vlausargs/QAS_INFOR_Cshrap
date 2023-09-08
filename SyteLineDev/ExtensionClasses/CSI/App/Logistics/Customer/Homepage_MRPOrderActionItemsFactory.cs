//PROJECT NAME: CSICustomer
//CLASS NAME: Homepage_MRPOrderActionItemsFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class Homepage_MRPOrderActionItemsFactory
	{
		public IHomepage_MRPOrderActionItems Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Homepage_MRPOrderActionItems = new Logistics.Customer.Homepage_MRPOrderActionItems(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHomepage_MRPOrderActionItemsExt = timerfactory.Create<Logistics.Customer.IHomepage_MRPOrderActionItems>(_Homepage_MRPOrderActionItems);
			
			return iHomepage_MRPOrderActionItemsExt;
		}
	}
}
