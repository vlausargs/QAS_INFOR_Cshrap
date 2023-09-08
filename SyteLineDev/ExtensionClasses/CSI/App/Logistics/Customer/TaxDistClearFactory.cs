//PROJECT NAME: Logistics
//CLASS NAME: TaxDistClearFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class TaxDistClearFactory
	{
		public ITaxDistClear Create(IApplicationDB appDB)
		{
			var _TaxDistClear = new Logistics.Customer.TaxDistClear(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTaxDistClearExt = timerfactory.Create<Logistics.Customer.ITaxDistClear>(_TaxDistClear);
			
			return iTaxDistClearExt;
		}
	}
}
