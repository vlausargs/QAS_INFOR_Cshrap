//PROJECT NAME: Logistics
//CLASS NAME: PromotionCodeValidFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
	public class PromotionCodeValidFactory
	{
		public IPromotionCodeValid Create(IApplicationDB appDB)
		{
			var _PromotionCodeValid = new Logistics.Customer.PromotionCodeValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPromotionCodeValidExt = timerfactory.Create<Logistics.Customer.IPromotionCodeValid>(_PromotionCodeValid);
			
			return iPromotionCodeValidExt;
		}
	}
}
