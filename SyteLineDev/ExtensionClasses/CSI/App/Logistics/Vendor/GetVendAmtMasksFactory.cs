//PROJECT NAME: CSIVendor
//CLASS NAME: GetVendAmtMasksFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GetVendAmtMasksFactory
	{
		public IGetVendAmtMasks Create(IApplicationDB appDB)
		{
			var _GetVendAmtMasks = new Logistics.Vendor.GetVendAmtMasks(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetVendAmtMasksExt = timerfactory.Create<Logistics.Vendor.IGetVendAmtMasks>(_GetVendAmtMasks);
			
			return iGetVendAmtMasksExt;
		}
	}
}
