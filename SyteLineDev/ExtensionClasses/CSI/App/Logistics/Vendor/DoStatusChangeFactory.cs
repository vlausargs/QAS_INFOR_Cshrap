//PROJECT NAME: CSIVendor
//CLASS NAME: DoStatusChangeFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class DoStatusChangeFactory
	{
		public IDoStatusChange Create(IApplicationDB appDB)
		{
			var _DoStatusChange = new Logistics.Vendor.DoStatusChange(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDoStatusChangeExt = timerfactory.Create<Logistics.Vendor.IDoStatusChange>(_DoStatusChange);
			
			return iDoStatusChangeExt;
		}
	}
}
