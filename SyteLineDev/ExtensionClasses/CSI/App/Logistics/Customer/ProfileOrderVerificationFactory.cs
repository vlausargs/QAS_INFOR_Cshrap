//PROJECT NAME: CSICustomer
//CLASS NAME: ProfileOrderVerificationFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class ProfileOrderVerificationFactory
	{
		public IProfileOrderVerification Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _ProfileOrderVerification = new Logistics.Customer.ProfileOrderVerification(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProfileOrderVerificationExt = timerfactory.Create<Logistics.Customer.IProfileOrderVerification>(_ProfileOrderVerification);
			
			return iProfileOrderVerificationExt;
		}
	}
}
