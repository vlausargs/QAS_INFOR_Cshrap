//PROJECT NAME: CSICustomer
//CLASS NAME: CoGetOrderActivity2Factory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class CoGetOrderActivity2Factory
	{
		public ICoGetOrderActivity2 Create(IApplicationDB appDB)
		{
			var _CoGetOrderActivity2 = new Logistics.Customer.CoGetOrderActivity2(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCoGetOrderActivity2Ext = timerfactory.Create<Logistics.Customer.ICoGetOrderActivity2>(_CoGetOrderActivity2);
			
			return iCoGetOrderActivity2Ext;
		}
	}
}
