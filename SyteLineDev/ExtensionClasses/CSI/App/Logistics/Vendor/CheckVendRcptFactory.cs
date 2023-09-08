//PROJECT NAME: CSIVendor
//CLASS NAME: CheckVendRcptFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class CheckVendRcptFactory
	{
		public ICheckVendRcpt Create(IApplicationDB appDB)
		{
			var _CheckVendRcpt = new Logistics.Vendor.CheckVendRcpt(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCheckVendRcptExt = timerfactory.Create<Logistics.Vendor.ICheckVendRcpt>(_CheckVendRcpt);
			
			return iCheckVendRcptExt;
		}
	}
}
