//PROJECT NAME: CSIVendor
//CLASS NAME: GetDropShipToAddrWithPhoneFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GetDropShipToAddrWithPhoneFactory
	{
		public IGetDropShipToAddrWithPhone Create(IApplicationDB appDB)
		{
			var _GetDropShipToAddrWithPhone = new Logistics.Vendor.GetDropShipToAddrWithPhone(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetDropShipToAddrWithPhoneExt = timerfactory.Create<Logistics.Vendor.IGetDropShipToAddrWithPhone>(_GetDropShipToAddrWithPhone);
			
			return iGetDropShipToAddrWithPhoneExt;
		}
	}
}
