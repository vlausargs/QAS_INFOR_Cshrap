//PROJECT NAME: Logistics
//CLASS NAME: TaxDistInsertFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class TaxDistInsertFactory
	{
		public ITaxDistInsert Create(IApplicationDB appDB)
		{
			var _TaxDistInsert = new Logistics.Customer.TaxDistInsert(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTaxDistInsertExt = timerfactory.Create<Logistics.Customer.ITaxDistInsert>(_TaxDistInsert);
			
			return iTaxDistInsertExt;
		}
	}
}
