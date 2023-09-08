//PROJECT NAME: CSICodes
//CLASS NAME: CustomerPortalCreateCustomer_1_CanCreateUsersFactory.cs

using CSI.MG;

namespace CSI.Codes
{
	public class CustomerPortalCreateCustomer_1_CanCreateUsersFactory
	{
		public ICustomerPortalCreateCustomer_1_CanCreateUsers Create(IApplicationDB appDB)
		{
			var _CustomerPortalCreateCustomer_1_CanCreateUsers = new Codes.CustomerPortalCreateCustomer_1_CanCreateUsers(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCustomerPortalCreateCustomer_1_CanCreateUsersExt = timerfactory.Create<Codes.ICustomerPortalCreateCustomer_1_CanCreateUsers>(_CustomerPortalCreateCustomer_1_CanCreateUsers);
			
			return iCustomerPortalCreateCustomer_1_CanCreateUsersExt;
		}
	}
}
