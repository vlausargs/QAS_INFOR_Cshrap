//PROJECT NAME: CSICustomer
//CLASS NAME: ArSummCustomerFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class ArSummCustomerFactory
	{
		public IArSummCustomer Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _ArSummCustomer = new Logistics.Customer.ArSummCustomer(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iArSummCustomerExt = timerfactory.Create<Logistics.Customer.IArSummCustomer>(_ArSummCustomer);
			
			return iArSummCustomerExt;
		}
	}
}
