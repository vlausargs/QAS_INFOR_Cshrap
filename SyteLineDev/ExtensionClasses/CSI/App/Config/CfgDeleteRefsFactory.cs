//PROJECT NAME: CSIConfig
//CLASS NAME: CfgDeleteRefsFactory.cs

using CSI.MG;

namespace CSI.Config
{
	public class CfgDeleteRefsFactory
	{
		public ICfgDeleteRefs Create(IApplicationDB appDB)
		{
			var _CfgDeleteRefs = new Config.CfgDeleteRefs(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCfgDeleteRefsExt = timerfactory.Create<Config.ICfgDeleteRefs>(_CfgDeleteRefs);
			
			return iCfgDeleteRefsExt;
		}
	}
}
