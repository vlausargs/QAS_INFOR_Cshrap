//PROJECT NAME: CSIVendor
//CLASS NAME: GetSupplQtyConvFactorFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class GetSupplQtyConvFactorFactory
	{
		public IGetSupplQtyConvFactor Create(IApplicationDB appDB)
		{
			var _GetSupplQtyConvFactor = new Logistics.Vendor.GetSupplQtyConvFactor(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetSupplQtyConvFactorExt = timerfactory.Create<Logistics.Vendor.IGetSupplQtyConvFactor>(_GetSupplQtyConvFactor);
			
			return iGetSupplQtyConvFactorExt;
		}
	}
}
