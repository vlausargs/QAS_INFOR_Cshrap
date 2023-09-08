//PROJECT NAME: CSIVendor
//CLASS NAME: ValidPoLcrNumFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class ValidPoLcrNumFactory
	{
		public IValidPoLcrNum Create(IApplicationDB appDB)
		{
			var _ValidPoLcrNum = new Logistics.Vendor.ValidPoLcrNum(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidPoLcrNumExt = timerfactory.Create<Logistics.Vendor.IValidPoLcrNum>(_ValidPoLcrNum);
			
			return iValidPoLcrNumExt;
		}
	}
}
