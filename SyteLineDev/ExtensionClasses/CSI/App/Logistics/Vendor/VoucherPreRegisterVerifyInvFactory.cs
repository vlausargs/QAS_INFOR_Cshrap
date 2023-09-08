//PROJECT NAME: Logistics
//CLASS NAME: VoucherPreRegisterVerifyInvFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class VoucherPreRegisterVerifyInvFactory
	{
		public IVoucherPreRegisterVerifyInv Create(IApplicationDB appDB)
		{
			var _VoucherPreRegisterVerifyInv = new Logistics.Vendor.VoucherPreRegisterVerifyInv(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iVoucherPreRegisterVerifyInvExt = timerfactory.Create<Logistics.Vendor.IVoucherPreRegisterVerifyInv>(_VoucherPreRegisterVerifyInv);
			
			return iVoucherPreRegisterVerifyInvExt;
		}
	}
}
