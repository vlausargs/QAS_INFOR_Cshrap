//PROJECT NAME: CSIVendor
//CLASS NAME: GenAPTransactionsPostRefreshFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GenAPTransactionsPostRefreshFactory
	{
		public IGenAPTransactionsPostRefresh Create(IApplicationDB appDB)
		{
			var _GenAPTransactionsPostRefresh = new Logistics.Vendor.GenAPTransactionsPostRefresh(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGenAPTransactionsPostRefreshExt = timerfactory.Create<Logistics.Vendor.IGenAPTransactionsPostRefresh>(_GenAPTransactionsPostRefresh);
			
			return iGenAPTransactionsPostRefreshExt;
		}
	}
}
