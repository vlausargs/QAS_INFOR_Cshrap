//PROJECT NAME: CSICustomer
//CLASS NAME: DelDoFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class DelDoFactory
	{
		public IDelDo Create(IApplicationDB appDB)
		{
			var _DelDo = new Logistics.Customer.DelDo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDelDoExt = timerfactory.Create<Logistics.Customer.IDelDo>(_DelDo);
			
			return iDelDoExt;
		}
	}
}
