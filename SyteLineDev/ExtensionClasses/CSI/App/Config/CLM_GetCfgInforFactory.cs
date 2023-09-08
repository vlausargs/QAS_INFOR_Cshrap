//PROJECT NAME: CSIConfig
//CLASS NAME: CLM_GetCfgInfFactory.cs

using CSI.MG;

namespace CSI.Config
{
	public class CLM_GetCfgInfFactory
	{
		public ICLM_GetCfgInf Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var _CLM_GetCfgInf = new Config.CLM_GetCfgInf(appDB, bunchedLoadCollection);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_GetCfgInfExt = timerfactory.Create<Config.ICLM_GetCfgInf>(_CLM_GetCfgInf);
			
			return iCLM_GetCfgInfExt;
		}
	}
}
