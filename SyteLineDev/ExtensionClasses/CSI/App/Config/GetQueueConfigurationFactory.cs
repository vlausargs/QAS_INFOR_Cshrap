//PROJECT NAME: CSIConfig
//CLASS NAME: GetQueueConfigurationFactory.cs

using CSI.MG;

namespace CSI.Config
{
	public class GetQueueConfigurationFactory
	{
		public IGetQueueConfiguration Create(IApplicationDB appDB)
		{
			var _GetQueueConfiguration = new Config.GetQueueConfiguration(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetQueueConfigurationExt = timerfactory.Create<Config.IGetQueueConfiguration>(_GetQueueConfiguration);
			
			return iGetQueueConfigurationExt;
		}
	}
}
