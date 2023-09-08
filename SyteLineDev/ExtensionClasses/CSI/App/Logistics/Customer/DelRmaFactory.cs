//PROJECT NAME: CSICustomer
//CLASS NAME: DelRmaFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class DelRmaFactory
	{
		public IDelRma Create(IApplicationDB appDB)
		{
			var _DelRma = new Logistics.Customer.DelRma(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDelRmaExt = timerfactory.Create<Logistics.Customer.IDelRma>(_DelRma);
			
			return iDelRmaExt;
		}
	}
}
