//PROJECT NAME: CSICustomer
//CLASS NAME: MoveLocalCustFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class MoveLocalCustFactory
	{
		public IMoveLocalCust Create(IApplicationDB appDB)
		{
			var _MoveLocalCust = new Logistics.Customer.MoveLocalCust(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMoveLocalCustExt = timerfactory.Create<Logistics.Customer.IMoveLocalCust>(_MoveLocalCust);
			
			return iMoveLocalCustExt;
		}
	}
}
