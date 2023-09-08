//PROJECT NAME: CSIVendor
//CLASS NAME: GrnApprovedLineExistsFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GrnApprovedLineExistsFactory
	{
		public IGrnApprovedLineExists Create(IApplicationDB appDB)
		{
			var _GrnApprovedLineExists = new Logistics.Vendor.GrnApprovedLineExists(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGrnApprovedLineExistsExt = timerfactory.Create<Logistics.Vendor.IGrnApprovedLineExists>(_GrnApprovedLineExists);
			
			return iGrnApprovedLineExistsExt;
		}
	}
}
