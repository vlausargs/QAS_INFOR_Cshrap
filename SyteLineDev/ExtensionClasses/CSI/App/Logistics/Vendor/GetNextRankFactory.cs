//PROJECT NAME: CSIVendor
//CLASS NAME: GetNextRankFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GetNextRankFactory
	{
		public IGetNextRank Create(IApplicationDB appDB)
		{
			var _GetNextRank = new Logistics.Vendor.GetNextRank(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetNextRankExt = timerfactory.Create<Logistics.Vendor.IGetNextRank>(_GetNextRank);
			
			return iGetNextRankExt;
		}
	}
}
