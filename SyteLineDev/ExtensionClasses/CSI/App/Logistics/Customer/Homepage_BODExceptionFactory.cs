//PROJECT NAME: CSICustomer
//CLASS NAME: Homepage_BODExceptionFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class Homepage_BODExceptionFactory
	{
		public IHomepage_BODException Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Homepage_BODException = new Logistics.Customer.Homepage_BODException(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHomepage_BODExceptionExt = timerfactory.Create<Logistics.Customer.IHomepage_BODException>(_Homepage_BODException);
			
			return iHomepage_BODExceptionExt;
		}
	}
}
