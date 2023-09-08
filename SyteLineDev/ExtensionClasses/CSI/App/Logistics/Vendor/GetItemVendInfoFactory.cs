//PROJECT NAME: CSIVendor
//CLASS NAME: GetItemVendInfoFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GetItemVendInfoFactory
	{
		public IGetItemVendInfo Create(IApplicationDB appDB)
		{
			var _GetItemVendInfo = new Logistics.Vendor.GetItemVendInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetItemVendInfoExt = timerfactory.Create<Logistics.Vendor.IGetItemVendInfo>(_GetItemVendInfo);
			
			return iGetItemVendInfoExt;
		}
	}
}
