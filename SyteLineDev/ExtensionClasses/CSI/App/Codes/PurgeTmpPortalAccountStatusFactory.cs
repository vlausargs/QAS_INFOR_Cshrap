//PROJECT NAME: CSICodes
//CLASS NAME: PurgeTmpPortalAccountStatusFactory.cs

using CSI.MG;

namespace CSI.Codes
{
	public class PurgeTmpPortalAccountStatusFactory
	{
		public IPurgeTmpPortalAccountStatus Create(IApplicationDB appDB)
		{
			var _PurgeTmpPortalAccountStatus = new Codes.PurgeTmpPortalAccountStatus(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPurgeTmpPortalAccountStatusExt = timerfactory.Create<Codes.IPurgeTmpPortalAccountStatus>(_PurgeTmpPortalAccountStatus);
			
			return iPurgeTmpPortalAccountStatusExt;
		}
	}
}
