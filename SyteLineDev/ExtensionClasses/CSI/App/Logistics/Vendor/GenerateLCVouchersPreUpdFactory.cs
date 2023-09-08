//PROJECT NAME: CSIVendor
//CLASS NAME: GenerateLCVouchersPreUpdFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GenerateLCVouchersPreUpdFactory
	{
		public IGenerateLCVouchersPreUpd Create(IApplicationDB appDB)
		{
			var _GenerateLCVouchersPreUpd = new Logistics.Vendor.GenerateLCVouchersPreUpd(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGenerateLCVouchersPreUpdExt = timerfactory.Create<Logistics.Vendor.IGenerateLCVouchersPreUpd>(_GenerateLCVouchersPreUpd);
			
			return iGenerateLCVouchersPreUpdExt;
		}
	}
}
