//PROJECT NAME: CSIVendor
//CLASS NAME: POReceiveQtyConvWrapperFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class POReceiveQtyConvWrapperFactory
	{
		public IPOReceiveQtyConvWrapper Create(IApplicationDB appDB)
		{
			var _POReceiveQtyConvWrapper = new Logistics.Vendor.POReceiveQtyConvWrapper(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPOReceiveQtyConvWrapperExt = timerfactory.Create<Logistics.Vendor.IPOReceiveQtyConvWrapper>(_POReceiveQtyConvWrapper);
			
			return iPOReceiveQtyConvWrapperExt;
		}
	}
}
