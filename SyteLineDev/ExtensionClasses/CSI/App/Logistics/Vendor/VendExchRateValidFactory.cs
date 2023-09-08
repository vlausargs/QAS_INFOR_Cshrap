//PROJECT NAME: Logistics
//CLASS NAME: VendExchRateValidFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class VendExchRateValidFactory
	{
		public IVendExchRateValid Create(IApplicationDB appDB)
		{
			var _VendExchRateValid = new Logistics.Vendor.VendExchRateValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iVendExchRateValidExt = timerfactory.Create<Logistics.Vendor.IVendExchRateValid>(_VendExchRateValid);
			
			return iVendExchRateValidExt;
		}
	}
}
