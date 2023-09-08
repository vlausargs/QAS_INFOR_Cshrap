//PROJECT NAME: Logistics
//CLASS NAME: RmaReplLoadDefaultsFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class RmaReplLoadDefaultsFactory
	{
		public IRmaReplLoadDefaults Create(IApplicationDB appDB)
		{
			var _RmaReplLoadDefaults = new Logistics.Customer.RmaReplLoadDefaults(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRmaReplLoadDefaultsExt = timerfactory.Create<Logistics.Customer.IRmaReplLoadDefaults>(_RmaReplLoadDefaults);
			
			return iRmaReplLoadDefaultsExt;
		}
	}
}
