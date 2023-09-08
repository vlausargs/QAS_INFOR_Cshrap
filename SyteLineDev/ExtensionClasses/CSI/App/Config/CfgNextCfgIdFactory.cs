//PROJECT NAME: CSIConfig
//CLASS NAME: CfgNextCfgIdFactory.cs

using CSI.MG;

namespace CSI.Config
{
	public class CfgNextCfgIdFactory
	{
		public ICfgNextCfgId Create(IApplicationDB appDB)
		{
			var _CfgNextCfgId = new Config.CfgNextCfgId(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCfgNextCfgIdExt = timerfactory.Create<Config.ICfgNextCfgId>(_CfgNextCfgId);
			
			return iCfgNextCfgIdExt;
		}
	}
}
