//PROJECT NAME: CSIVendor
//CLASS NAME: GetVchPrFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GetVchPrFactory
	{
		public IGetVchPr Create(IApplicationDB appDB)
		{
			var _GetVchPr = new Logistics.Vendor.GetVchPr(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetVchPrExt = timerfactory.Create<Logistics.Vendor.IGetVchPr>(_GetVchPr);
			
			return iGetVchPrExt;
		}
	}
}
