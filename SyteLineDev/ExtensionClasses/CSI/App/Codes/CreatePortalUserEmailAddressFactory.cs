//PROJECT NAME: CSICodes
//CLASS NAME: CreatePortalUserEmailAddressFactory.cs

using CSI.MG;

namespace CSI.Codes
{
	public class CreatePortalUserEmailAddressFactory
	{
		public ICreatePortalUserEmailAddress Create(IApplicationDB appDB)
		{
			var _CreatePortalUserEmailAddress = new Codes.CreatePortalUserEmailAddress(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCreatePortalUserEmailAddressExt = timerfactory.Create<Codes.ICreatePortalUserEmailAddress>(_CreatePortalUserEmailAddress);
			
			return iCreatePortalUserEmailAddressExt;
		}
	}
}
