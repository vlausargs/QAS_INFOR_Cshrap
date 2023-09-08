//PROJECT NAME: CSIVendor
//CLASS NAME: MoveLocalVendFactory.cs

using CSI.MG;

namespace CSI.Logistics.Vendor
{
	public class MoveLocalVendFactory
	{
		public IMoveLocalVend Create(IApplicationDB appDB)
		{
			var _MoveLocalVend = new Logistics.Vendor.MoveLocalVend(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMoveLocalVendExt = timerfactory.Create<Logistics.Vendor.IMoveLocalVend>(_MoveLocalVend);
			
			return iMoveLocalVendExt;
		}
	}
}
