//PROJECT NAME: CSIConfig
//CLASS NAME: CfgSetConfigIdFactory.cs

using CSI.MG;

namespace CSI.Config
{
	public class CfgSetConfigIdFactory
	{
		public ICfgSetConfigId Create(IApplicationDB appDB)
		{
			var _CfgSetConfigId = new Config.CfgSetConfigId(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCfgSetConfigIdExt = timerfactory.Create<Config.ICfgSetConfigId>(_CfgSetConfigId);
			
			return iCfgSetConfigIdExt;
		}
	}
}
