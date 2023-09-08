//PROJECT NAME: CSIVendor
//CLASS NAME: GRNAllocFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GrnallocFactory
	{
		public IGrnalloc Create(IApplicationDB appDB)
		{
			var _GRNAlloc = new Logistics.Vendor.Grnalloc(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGRNAllocExt = timerfactory.Create<Logistics.Vendor.IGrnalloc>(_GRNAlloc);
			
			return iGRNAllocExt;
		}
	}
}
