//PROJECT NAME: CSICustomer
//CLASS NAME: ARBalanceHistoryFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class ARBalanceHistoryFactory
	{
		public IARBalanceHistory Create(IApplicationDB appDB)
		{
			var _ARBalanceHistory = new Logistics.Customer.ARBalanceHistory(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iARBalanceHistoryExt = timerfactory.Create<Logistics.Customer.IARBalanceHistory>(_ARBalanceHistory);
			
			return iARBalanceHistoryExt;
		}
	}
}
