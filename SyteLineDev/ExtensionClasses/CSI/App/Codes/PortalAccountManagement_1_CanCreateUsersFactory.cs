//PROJECT NAME: CSICodes
//CLASS NAME: PortalAccountManagement_1_CanCreateUsersFactory.cs

using CSI.MG;

namespace CSI.Codes
{
	public class PortalAccountManagement_1_CanCreateUsersFactory
	{
		public IPortalAccountManagement_1_CanCreateUsers Create(IApplicationDB appDB)
		{
			var _PortalAccountManagement_1_CanCreateUsers = new Codes.PortalAccountManagement_1_CanCreateUsers(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPortalAccountManagement_1_CanCreateUsersExt = timerfactory.Create<Codes.IPortalAccountManagement_1_CanCreateUsers>(_PortalAccountManagement_1_CanCreateUsers);
			
			return iPortalAccountManagement_1_CanCreateUsersExt;
		}
	}
}
