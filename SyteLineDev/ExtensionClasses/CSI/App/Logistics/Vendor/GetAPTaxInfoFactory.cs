//PROJECT NAME: CSIVendor
//CLASS NAME: GetAPTaxInfoFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GetAPTaxInfoFactory
	{
		public IGetAPTaxInfo Create(IApplicationDB appDB)
		{
			var _GetAPTaxInfo = new Logistics.Vendor.GetAPTaxInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetAPTaxInfoExt = timerfactory.Create<Logistics.Vendor.IGetAPTaxInfo>(_GetAPTaxInfo);
			
			return iGetAPTaxInfoExt;
		}
	}
}
