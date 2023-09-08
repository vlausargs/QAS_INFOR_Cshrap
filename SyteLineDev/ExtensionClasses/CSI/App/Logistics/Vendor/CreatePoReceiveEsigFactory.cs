//PROJECT NAME: CSIVendor
//CLASS NAME: CreatePoReceiveEsigFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class CreatePoReceiveEsigFactory
	{
		public ICreatePoReceiveEsig Create(IApplicationDB appDB)
		{
			var _CreatePoReceiveEsig = new Logistics.Vendor.CreatePoReceiveEsig(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCreatePoReceiveEsigExt = timerfactory.Create<Logistics.Vendor.ICreatePoReceiveEsig>(_CreatePoReceiveEsig);
			
			return iCreatePoReceiveEsigExt;
		}
	}
}
