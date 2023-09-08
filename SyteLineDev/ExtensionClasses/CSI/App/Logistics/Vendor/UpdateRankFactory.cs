//PROJECT NAME: CSIVendor
//CLASS NAME: UpdateRankFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class UpdateRankFactory
	{
		public IUpdateRank Create(IApplicationDB appDB)
		{
			var _UpdateRank = new Logistics.Vendor.UpdateRank(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUpdateRankExt = timerfactory.Create<Logistics.Vendor.IUpdateRank>(_UpdateRank);
			
			return iUpdateRankExt;
		}
	}
}
