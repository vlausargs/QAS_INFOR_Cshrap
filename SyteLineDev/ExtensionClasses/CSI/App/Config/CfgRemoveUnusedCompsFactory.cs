//PROJECT NAME: Config
//CLASS NAME: CfgRemoveUnusedCompsFactory.cs

using CSI.MG;

namespace CSI.Config
{
	public class CfgRemoveUnusedCompsFactory
	{
		public ICfgRemoveUnusedComps Create(IApplicationDB appDB)
		{
			var _CfgRemoveUnusedComps = new Config.CfgRemoveUnusedComps(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCfgRemoveUnusedCompsExt = timerfactory.Create<Config.ICfgRemoveUnusedComps>(_CfgRemoveUnusedComps);
			
			return iCfgRemoveUnusedCompsExt;
		}
	}
}
