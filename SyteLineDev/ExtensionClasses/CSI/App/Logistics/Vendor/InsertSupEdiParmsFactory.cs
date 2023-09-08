//PROJECT NAME: CSIVendor
//CLASS NAME: InsertSupEdiParmsFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class InsertSupEdiParmsFactory
	{
		public IInsertSupEdiParms Create(IApplicationDB appDB)
		{
			var _InsertSupEdiParms = new Logistics.Vendor.InsertSupEdiParms(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iInsertSupEdiParmsExt = timerfactory.Create<Logistics.Vendor.IInsertSupEdiParms>(_InsertSupEdiParms);
			
			return iInsertSupEdiParmsExt;
		}
	}
}
