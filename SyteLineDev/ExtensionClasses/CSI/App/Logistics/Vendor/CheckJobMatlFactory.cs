//PROJECT NAME: CSIVendor
//CLASS NAME: CheckJobMatlFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class CheckJobMatlFactory
	{
		public ICheckJobMatl Create(IApplicationDB appDB)
		{
			var _CheckJobMatl = new Logistics.Vendor.CheckJobMatl(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCheckJobMatlExt = timerfactory.Create<Logistics.Vendor.ICheckJobMatl>(_CheckJobMatl);
			
			return iCheckJobMatlExt;
		}
	}
}
