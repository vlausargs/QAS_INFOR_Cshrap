//PROJECT NAME: CSIConfig
//CLASS NAME: CfgClearRefsFactory.cs

using CSI.MG;

namespace CSI.Config
{
	public class CfgClearRefsFactory
	{
		public ICfgClearRefs Create(IApplicationDB appDB)
		{
			var _CfgClearRefs = new Config.CfgClearRefs(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCfgClearRefsExt = timerfactory.Create<Config.ICfgClearRefs>(_CfgClearRefs);
			
			return iCfgClearRefsExt;
		}
	}
}
