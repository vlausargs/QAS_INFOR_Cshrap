//PROJECT NAME: CSICustomer
//CLASS NAME: ProfileBillofLadingFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class ProfileBillofLadingFactory
	{
		public IProfileBillofLading Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _ProfileBillofLading = new Logistics.Customer.ProfileBillofLading(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProfileBillofLadingExt = timerfactory.Create<Logistics.Customer.IProfileBillofLading>(_ProfileBillofLading);
			
			return iProfileBillofLadingExt;
		}
	}
}
