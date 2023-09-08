//PROJECT NAME: Logistics
//CLASS NAME: TaxFactFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class TaxFactFactory
	{
		public ITaxFact Create(IApplicationDB appDB)
		{
			var _TaxFact = new Logistics.Customer.TaxFact(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTaxFactExt = timerfactory.Create<Logistics.Customer.ITaxFact>(_TaxFact);
			
			return iTaxFactExt;
		}
	}
}
