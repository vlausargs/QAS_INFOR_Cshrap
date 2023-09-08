//PROJECT NAME: CSIVendor
//CLASS NAME: GetAPAgingInfoBySiteGroupFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GetAPAgingInfoBySiteGroupFactory
	{
		public IGetAPAgingInfoBySiteGroup Create(IApplicationDB appDB)
		{
			var _GetAPAgingInfoBySiteGroup = new Logistics.Vendor.GetAPAgingInfoBySiteGroup(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetAPAgingInfoBySiteGroupExt = timerfactory.Create<Logistics.Vendor.IGetAPAgingInfoBySiteGroup>(_GetAPAgingInfoBySiteGroup);
			
			return iGetAPAgingInfoBySiteGroupExt;
		}
	}
}
