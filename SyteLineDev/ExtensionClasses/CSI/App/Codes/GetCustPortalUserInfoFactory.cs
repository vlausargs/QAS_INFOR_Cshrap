//PROJECT NAME: CSICodes
//CLASS NAME: GetCustPortalUserInfoFactory.cs

using CSI.MG;

namespace CSI.Codes
{
	public class GetCustPortalUserInfoFactory
	{
		public IGetCustPortalUserInfo Create(IApplicationDB appDB)
		{
			var _GetCustPortalUserInfo = new Codes.GetCustPortalUserInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetCustPortalUserInfoExt = timerfactory.Create<Codes.IGetCustPortalUserInfo>(_GetCustPortalUserInfo);
			
			return iGetCustPortalUserInfoExt;
		}
	}
}
