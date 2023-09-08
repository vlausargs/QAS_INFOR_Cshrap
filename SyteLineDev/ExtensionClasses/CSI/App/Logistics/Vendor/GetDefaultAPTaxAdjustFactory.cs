//PROJECT NAME: Logistics
//CLASS NAME: GetDefaultAPTaxAdjustFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GetDefaultAPTaxAdjustFactory
	{
		public IGetDefaultAPTaxAdjust Create(IApplicationDB appDB)
		{
			var _GetDefaultAPTaxAdjust = new Logistics.Vendor.GetDefaultAPTaxAdjust(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetDefaultAPTaxAdjustExt = timerfactory.Create<Logistics.Vendor.IGetDefaultAPTaxAdjust>(_GetDefaultAPTaxAdjust);
			
			return iGetDefaultAPTaxAdjustExt;
		}
	}
}
