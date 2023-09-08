//PROJECT NAME: CSIVendor
//CLASS NAME: GetGRNInfoFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GetGRNInfoFactory
	{
		public IGetGRNInfo Create(IApplicationDB appDB)
		{
			var _GetGRNInfo = new Logistics.Vendor.GetGRNInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetGRNInfoExt = timerfactory.Create<Logistics.Vendor.IGetGRNInfo>(_GetGRNInfo);
			
			return iGetGRNInfoExt;
		}
	}
}
