//PROJECT NAME: CSIVendor
//CLASS NAME: GetVendAddrInfoFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GetVendAddrInfoFactory
	{
		public IGetVendAddrInfo Create(IApplicationDB appDB)
		{
			var _GetVendAddrInfo = new Logistics.Vendor.GetVendAddrInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetVendAddrInfoExt = timerfactory.Create<Logistics.Vendor.IGetVendAddrInfo>(_GetVendAddrInfo);
			
			return iGetVendAddrInfoExt;
		}
	}
}
