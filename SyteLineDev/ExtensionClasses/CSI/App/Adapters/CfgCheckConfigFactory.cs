//PROJECT NAME: Adapters
//CLASS NAME: CfgCheckConfigFactory.cs

using CSI.MG;

namespace CSI.Adapters
{
	public class CfgCheckConfigFactory
	{
		public ICfgCheckConfig Create(IApplicationDB appDB)
		{
			var _CfgCheckConfig = new Adapters.CfgCheckConfig(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCfgCheckConfigExt = timerfactory.Create<Adapters.ICfgCheckConfig>(_CfgCheckConfig);
			
			return iCfgCheckConfigExt;
		}
	}
}
