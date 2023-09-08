//PROJECT NAME: CSIVendor
//CLASS NAME: GetAptrxFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GetAptrxFactory
	{
		public IGetAptrx Create(IApplicationDB appDB)
		{
			var _GetAptrx = new Logistics.Vendor.GetAptrx(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetAptrxExt = timerfactory.Create<Logistics.Vendor.IGetAptrx>(_GetAptrx);
			
			return iGetAptrxExt;
		}
	}
}
