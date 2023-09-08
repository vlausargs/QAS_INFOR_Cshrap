//PROJECT NAME: CSIVendor
//CLASS NAME: GetPoParmsFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GetPoParmsFactory
	{
		public IGetPoParms Create(IApplicationDB appDB)
		{
			var _GetPoParms = new Logistics.Vendor.GetPoParms(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetPoParmsExt = timerfactory.Create<Logistics.Vendor.IGetPoParms>(_GetPoParms);
			
			return iGetPoParmsExt;
		}
	}
}
