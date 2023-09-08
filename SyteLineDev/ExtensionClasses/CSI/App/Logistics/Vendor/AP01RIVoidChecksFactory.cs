//PROJECT NAME: CSIVendor
//CLASS NAME: AP01RIVoidChecksFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class AP01RIVoidChecksFactory
	{
		public IAP01RIVoidChecks Create(IApplicationDB appDB)
		{
			var _AP01RIVoidChecks = new Logistics.Vendor.AP01RIVoidChecks(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAP01RIVoidChecksExt = timerfactory.Create<Logistics.Vendor.IAP01RIVoidChecks>(_AP01RIVoidChecks);
			
			return iAP01RIVoidChecksExt;
		}
	}
}
