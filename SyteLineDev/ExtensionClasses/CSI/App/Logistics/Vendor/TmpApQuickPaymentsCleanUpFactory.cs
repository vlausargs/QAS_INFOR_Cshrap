//PROJECT NAME: Logistics
//CLASS NAME: TmpApQuickPaymentsCleanUpFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class TmpApQuickPaymentsCleanUpFactory
	{
		public ITmpApQuickPaymentsCleanUp Create(IApplicationDB appDB)
		{
			var _TmpApQuickPaymentsCleanUp = new Logistics.Vendor.TmpApQuickPaymentsCleanUp(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTmpApQuickPaymentsCleanUpExt = timerfactory.Create<Logistics.Vendor.ITmpApQuickPaymentsCleanUp>(_TmpApQuickPaymentsCleanUp);
			
			return iTmpApQuickPaymentsCleanUpExt;
		}
	}
}
