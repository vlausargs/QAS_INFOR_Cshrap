//PROJECT NAME: CSIVendor
//CLASS NAME: DefAPPostedTransFilterFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class DefAPPostedTransFilterFactory
	{
		public IDefAPPostedTransFilter Create(IApplicationDB appDB)
		{
			var _DefAPPostedTransFilter = new Logistics.Vendor.DefAPPostedTransFilter(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDefAPPostedTransFilterExt = timerfactory.Create<Logistics.Vendor.IDefAPPostedTransFilter>(_DefAPPostedTransFilter);
			
			return iDefAPPostedTransFilterExt;
		}
	}
}
