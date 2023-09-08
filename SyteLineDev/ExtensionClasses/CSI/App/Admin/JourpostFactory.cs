//PROJECT NAME: Admin
//CLASS NAME: JourpostFactory.cs

using CSI.MG;

namespace CSI.Admin
{
	public class JourpostFactory
	{
		public IJourpost Create(IApplicationDB appDB)
		{
			var _Jourpost = new Admin.Jourpost(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJourpostExt = timerfactory.Create<Admin.IJourpost>(_Jourpost);
			
			return iJourpostExt;
		}
	}
}
