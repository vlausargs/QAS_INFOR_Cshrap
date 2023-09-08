//PROJECT NAME: Logistics
//CLASS NAME: TaxDistCountFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class TaxDistCountFactory
	{
		public ITaxDistCount Create(IApplicationDB appDB)
		{
			var _TaxDistCount = new Logistics.Customer.TaxDistCount(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTaxDistCountExt = timerfactory.Create<Logistics.Customer.ITaxDistCount>(_TaxDistCount);
			
			return iTaxDistCountExt;
		}
	}
}
