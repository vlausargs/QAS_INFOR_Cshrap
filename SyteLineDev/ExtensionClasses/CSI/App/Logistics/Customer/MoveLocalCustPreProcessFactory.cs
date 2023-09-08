//PROJECT NAME: CSICustomer
//CLASS NAME: MoveLocalCustPreProcessFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class MoveLocalCustPreProcessFactory
	{
		public IMoveLocalCustPreProcess Create(IApplicationDB appDB)
		{
			var _MoveLocalCustPreProcess = new Logistics.Customer.MoveLocalCustPreProcess(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMoveLocalCustPreProcessExt = timerfactory.Create<Logistics.Customer.IMoveLocalCustPreProcess>(_MoveLocalCustPreProcess);
			
			return iMoveLocalCustPreProcessExt;
		}
	}
}
