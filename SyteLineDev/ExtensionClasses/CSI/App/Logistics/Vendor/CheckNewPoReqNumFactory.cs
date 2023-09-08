//PROJECT NAME: CSIVendor
//CLASS NAME: CheckNewPoReqNumFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class CheckNewPoReqNumFactory
	{
		public ICheckNewPoReqNum Create(IApplicationDB appDB)
		{
			var _CheckNewPoReqNum = new Logistics.Vendor.CheckNewPoReqNum(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCheckNewPoReqNumExt = timerfactory.Create<Logistics.Vendor.ICheckNewPoReqNum>(_CheckNewPoReqNum);
			
			return iCheckNewPoReqNumExt;
		}
	}
}
