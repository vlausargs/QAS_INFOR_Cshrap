//PROJECT NAME: Codes
//CLASS NAME: AlertNotifyTaskBODDistributionPersonIdFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Codes
{
	public class AlertNotifyTaskBODDistributionPersonIdFactory
	{
		public IAlertNotifyTaskBODDistributionPersonId Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _AlertNotifyTaskBODDistributionPersonId = new Codes.AlertNotifyTaskBODDistributionPersonId(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAlertNotifyTaskBODDistributionPersonIdExt = timerfactory.Create<Codes.IAlertNotifyTaskBODDistributionPersonId>(_AlertNotifyTaskBODDistributionPersonId);
			
			return iAlertNotifyTaskBODDistributionPersonIdExt;
		}
	}
}
