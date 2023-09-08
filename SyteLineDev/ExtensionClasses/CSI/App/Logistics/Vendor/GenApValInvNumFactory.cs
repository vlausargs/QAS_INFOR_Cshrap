//PROJECT NAME: CSIVendor
//CLASS NAME: GenApValInvNumFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GenApValInvNumFactory
	{
		public IGenApValInvNum Create(IApplicationDB appDB)
		{
			var _GenApValInvNum = new Logistics.Vendor.GenApValInvNum(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGenApValInvNumExt = timerfactory.Create<Logistics.Vendor.IGenApValInvNum>(_GenApValInvNum);
			
			return iGenApValInvNumExt;
		}
	}
}
