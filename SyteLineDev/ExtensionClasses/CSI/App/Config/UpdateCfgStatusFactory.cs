//PROJECT NAME: CSIConfig
//CLASS NAME: UpdateCfgStatusFactory.cs

using CSI.MG;

namespace CSI.Config
{
	public class UpdateCfgStatusFactory
	{
		public IUpdateCfgStatus Create(IApplicationDB appDB)
		{
			var _UpdateCfgStatus = new Config.UpdateCfgStatus(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUpdateCfgStatusExt = timerfactory.Create<Config.IUpdateCfgStatus>(_UpdateCfgStatus);
			
			return iUpdateCfgStatusExt;
		}
	}
}
