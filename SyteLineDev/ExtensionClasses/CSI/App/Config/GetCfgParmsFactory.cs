//PROJECT NAME: CSIConfig
//CLASS NAME: GetCfgParmsFactory.cs

using CSI.MG;

namespace CSI.Config
{
	public class GetCfgParmsFactory
	{
		public IGetCfgParms Create(IApplicationDB appDB)
		{
			var _GetCfgParms = new Config.GetCfgParms(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetCfgParmsExt = timerfactory.Create<Config.IGetCfgParms>(_GetCfgParms);
			
			return iGetCfgParmsExt;
		}
	}
}
