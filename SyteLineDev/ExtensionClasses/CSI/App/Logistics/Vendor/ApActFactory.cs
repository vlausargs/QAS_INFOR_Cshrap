//PROJECT NAME: CSIVendor
//CLASS NAME: ApActFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class ApActFactory
	{
		public IApAct Create(IApplicationDB appDB)
		{
			var _ApAct = new Logistics.Vendor.ApAct(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApActExt = timerfactory.Create<Logistics.Vendor.IApAct>(_ApAct);
			
			return iApActExt;
		}
	}
}
