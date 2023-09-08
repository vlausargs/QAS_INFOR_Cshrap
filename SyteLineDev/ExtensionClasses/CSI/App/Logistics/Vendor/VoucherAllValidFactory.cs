//PROJECT NAME: Logistics
//CLASS NAME: VoucherAllValidFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class VoucherAllValidFactory
	{
		public IVoucherAllValid Create(IApplicationDB appDB)
		{
			var _VoucherAllValid = new Logistics.Vendor.VoucherAllValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iVoucherAllValidExt = timerfactory.Create<Logistics.Vendor.IVoucherAllValid>(_VoucherAllValid);
			
			return iVoucherAllValidExt;
		}
	}
}
