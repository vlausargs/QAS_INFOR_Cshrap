//PROJECT NAME: Logistics
//CLASS NAME: GetCoLinePlanAndPriceParmsFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetCoLinePlanAndPriceParmsFactory
	{
		public IGetCoLinePlanAndPriceParms Create(IApplicationDB appDB)
		{
			var _GetCoLinePlanAndPriceParms = new Logistics.Customer.GetCoLinePlanAndPriceParms(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetCoLinePlanAndPriceParmsExt = timerfactory.Create<Logistics.Customer.IGetCoLinePlanAndPriceParms>(_GetCoLinePlanAndPriceParms);
			
			return iGetCoLinePlanAndPriceParmsExt;
		}
	}
}
