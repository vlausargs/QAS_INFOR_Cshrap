//PROJECT NAME: Logistics
//CLASS NAME: TranUdFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class TranUdFactory
	{
		public ITranUd Create(IApplicationDB appDB)
		{
			var _TranUd = new Logistics.Customer.TranUd(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTranUdExt = timerfactory.Create<Logistics.Customer.ITranUd>(_TranUd);
			
			return iTranUdExt;
		}
	}
}
