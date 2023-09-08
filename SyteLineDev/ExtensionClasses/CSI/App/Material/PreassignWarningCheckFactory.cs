//PROJECT NAME: CSIMaterial
//CLASS NAME: PreassignWarningCheckFactory.cs

using CSI.MG;

namespace CSI.Material
{
	public class PreassignWarningCheckFactory
	{
		public IPreassignWarningCheck Create(IApplicationDB appDB)
		{
			var _PreassignWarningCheck = new Material.PreassignWarningCheck(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPreassignWarningCheckExt = timerfactory.Create<Material.IPreassignWarningCheck>(_PreassignWarningCheck);
			
			return iPreassignWarningCheckExt;
		}
	}
}
