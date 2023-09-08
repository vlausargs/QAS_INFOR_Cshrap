//PROJECT NAME: CSIVendor
//CLASS NAME: DetermineVoucherStatusForVatFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class DetermineVoucherStatusForVatFactory
	{
		public IDetermineVoucherStatusForVat Create(IApplicationDB appDB)
		{
			var _DetermineVoucherStatusForVat = new Logistics.Vendor.DetermineVoucherStatusForVat(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDetermineVoucherStatusForVatExt = timerfactory.Create<Logistics.Vendor.IDetermineVoucherStatusForVat>(_DetermineVoucherStatusForVat);
			
			return iDetermineVoucherStatusForVatExt;
		}
	}
}
