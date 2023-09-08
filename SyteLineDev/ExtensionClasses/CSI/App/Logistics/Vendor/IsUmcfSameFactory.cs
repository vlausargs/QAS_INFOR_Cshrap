//PROJECT NAME: CSIVendor
//CLASS NAME: IsUmcfSameFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class IsUmcfSameFactory
	{
		public IIsUmcfSame Create(IApplicationDB appDB)
		{
			var _IsUmcfSame = new Logistics.Vendor.IsUmcfSame(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iIsUmcfSameExt = timerfactory.Create<Logistics.Vendor.IIsUmcfSame>(_IsUmcfSame);
			
			return iIsUmcfSameExt;
		}
	}
}
