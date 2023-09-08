//PROJECT NAME: CSIVendor
//CLASS NAME: CheckNewPoNumFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class CheckNewPoNumFactory
	{
		public ICheckNewPoNum Create(IApplicationDB appDB)
		{
			var _CheckNewPoNum = new Logistics.Vendor.CheckNewPoNum(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCheckNewPoNumExt = timerfactory.Create<Logistics.Vendor.ICheckNewPoNum>(_CheckNewPoNum);
			
			return iCheckNewPoNumExt;
		}
	}
}
