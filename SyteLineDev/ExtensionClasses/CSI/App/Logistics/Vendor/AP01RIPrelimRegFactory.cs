//PROJECT NAME: CSIVendor
//CLASS NAME: AP01RIPrelimRegFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class AP01RIPrelimRegFactory
	{
		public IAP01RIPrelimReg Create(IApplicationDB appDB)
		{
			var _AP01RIPrelimReg = new Logistics.Vendor.AP01RIPrelimReg(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAP01RIPrelimRegExt = timerfactory.Create<Logistics.Vendor.IAP01RIPrelimReg>(_AP01RIPrelimReg);
			
			return iAP01RIPrelimRegExt;
		}
	}
}
