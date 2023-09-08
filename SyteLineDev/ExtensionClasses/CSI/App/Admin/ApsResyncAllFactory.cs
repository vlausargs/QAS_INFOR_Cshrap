//PROJECT NAME: Admin
//CLASS NAME: ApsResyncAllFactory.cs

using CSI.MG;

namespace CSI.Admin
{
	public class ApsResyncAllFactory
	{
		public IApsResyncAll Create(IApplicationDB appDB)
		{
			var _ApsResyncAll = new Admin.ApsResyncAll(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsResyncAllExt = timerfactory.Create<Admin.IApsResyncAll>(_ApsResyncAll);
			
			return iApsResyncAllExt;
		}
	}
}
