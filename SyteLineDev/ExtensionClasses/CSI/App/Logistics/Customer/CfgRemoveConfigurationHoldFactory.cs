//PROJECT NAME: Logistics
//CLASS NAME: CfgRemoveConfigurationHoldFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class CfgRemoveConfigurationHoldFactory
	{
		public ICfgRemoveConfigurationHold Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CfgRemoveConfigurationHold = new Logistics.Customer.CfgRemoveConfigurationHold(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCfgRemoveConfigurationHoldExt = timerfactory.Create<Logistics.Customer.ICfgRemoveConfigurationHold>(_CfgRemoveConfigurationHold);
			
			return iCfgRemoveConfigurationHoldExt;
		}
	}
}
