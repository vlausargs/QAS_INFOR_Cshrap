//PROJECT NAME: CSIVendor
//CLASS NAME: PreCheckLinkSourceSiteCOFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class PreCheckLinkSourceSiteCOFactory
	{
		public IPreCheckLinkSourceSiteCO Create(IApplicationDB appDB)
		{
			var _PreCheckLinkSourceSiteCO = new Logistics.Vendor.PreCheckLinkSourceSiteCO(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPreCheckLinkSourceSiteCOExt = timerfactory.Create<Logistics.Vendor.IPreCheckLinkSourceSiteCO>(_PreCheckLinkSourceSiteCO);
			
			return iPreCheckLinkSourceSiteCOExt;
		}
	}
}
