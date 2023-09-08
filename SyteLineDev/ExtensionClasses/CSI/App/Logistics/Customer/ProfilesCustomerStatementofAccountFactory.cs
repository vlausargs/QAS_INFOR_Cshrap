//PROJECT NAME: CSICustomer
//CLASS NAME: ProfilesCustomerStatementofAccountFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Logistics.Customer
{
	public class ProfilesCustomerStatementofAccountFactory
	{
		public IProfilesCustomerStatementofAccount Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _ProfilesCustomerStatementofAccount = new Logistics.Customer.ProfilesCustomerStatementofAccount(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProfilesCustomerStatementofAccountExt = timerfactory.Create<Logistics.Customer.IProfilesCustomerStatementofAccount>(_ProfilesCustomerStatementofAccount);
			
			return iProfilesCustomerStatementofAccountExt;
		}
	}
}
