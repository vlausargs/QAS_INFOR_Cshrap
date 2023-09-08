//PROJECT NAME: CSIVendor
//CLASS NAME: POValidateNegativeQtyFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class POValidateNegativeQtyFactory
	{
		public IPOValidateNegativeQty Create(IApplicationDB appDB)
		{
			var _POValidateNegativeQty = new Logistics.Vendor.POValidateNegativeQty(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPOValidateNegativeQtyExt = timerfactory.Create<Logistics.Vendor.IPOValidateNegativeQty>(_POValidateNegativeQty);
			
			return iPOValidateNegativeQtyExt;
		}
	}
}
