//PROJECT NAME: CSIVendor
//CLASS NAME: AP01RIVoidChecksRangeFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class AP01RIVoidChecksRangeFactory
	{
		public IAP01RIVoidChecksRange Create(IApplicationDB appDB)
		{
			var _AP01RIVoidChecksRange = new Logistics.Vendor.AP01RIVoidChecksRange(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iAP01RIVoidChecksRangeExt = timerfactory.Create<Logistics.Vendor.IAP01RIVoidChecksRange>(_AP01RIVoidChecksRange);
			
			return iAP01RIVoidChecksRangeExt;
		}
	}
}
