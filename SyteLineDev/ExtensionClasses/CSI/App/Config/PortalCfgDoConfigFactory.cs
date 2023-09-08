//PROJECT NAME: CSIConfig
//CLASS NAME: PortalCfgDoConfigFactory.cs

using CSI.MG;

namespace CSI.Config
{
	public class PortalCfgDoConfigFactory
	{
		public IPortalCfgDoConfig Create(IApplicationDB appDB)
		{
			var _PortalCfgDoConfig = new Config.PortalCfgDoConfig(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPortalCfgDoConfigExt = timerfactory.Create<Config.IPortalCfgDoConfig>(_PortalCfgDoConfig);
			
			return iPortalCfgDoConfigExt;
		}
	}
}
