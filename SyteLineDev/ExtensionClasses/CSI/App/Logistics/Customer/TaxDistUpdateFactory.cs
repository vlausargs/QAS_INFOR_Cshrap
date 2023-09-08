//PROJECT NAME: Logistics
//CLASS NAME: TaxDistUpdateFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class TaxDistUpdateFactory
	{
		public ITaxDistUpdate Create(IApplicationDB appDB)
		{
			var _TaxDistUpdate = new Logistics.Customer.TaxDistUpdate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTaxDistUpdateExt = timerfactory.Create<Logistics.Customer.ITaxDistUpdate>(_TaxDistUpdate);
			
			return iTaxDistUpdateExt;
		}
	}
}
