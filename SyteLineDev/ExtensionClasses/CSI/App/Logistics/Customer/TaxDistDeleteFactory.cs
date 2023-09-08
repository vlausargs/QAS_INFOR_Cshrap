//PROJECT NAME: Logistics
//CLASS NAME: TaxDistDeleteFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class TaxDistDeleteFactory
	{
		public ITaxDistDelete Create(IApplicationDB appDB)
		{
			var _TaxDistDelete = new Logistics.Customer.TaxDistDelete(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTaxDistDeleteExt = timerfactory.Create<Logistics.Customer.ITaxDistDelete>(_TaxDistDelete);
			
			return iTaxDistDeleteExt;
		}
	}
}
