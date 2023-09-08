//PROJECT NAME: CSIVendor
//CLASS NAME: GetAPAgeDaysFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GetAPAgeDaysFactory
	{
		public IGetAPAgeDays Create(IApplicationDB appDB)
		{
			var _GetAPAgeDays = new Logistics.Vendor.GetAPAgeDays(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetAPAgeDaysExt = timerfactory.Create<Logistics.Vendor.IGetAPAgeDays>(_GetAPAgeDays);
			
			return iGetAPAgeDaysExt;
		}
	}
}
