//PROJECT NAME: CSICustomer
//CLASS NAME: GetUseAltPriceParmsFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class GetUseAltPriceParmsFactory
	{
		public IGetUseAltPriceParms Create(IApplicationDB appDB)
		{
			var _GetUseAltPriceParms = new Logistics.Customer.GetUseAltPriceParms(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetUseAltPriceParmsExt = timerfactory.Create<Logistics.Customer.IGetUseAltPriceParms>(_GetUseAltPriceParms);
			
			return iGetUseAltPriceParmsExt;
		}
	}
}
