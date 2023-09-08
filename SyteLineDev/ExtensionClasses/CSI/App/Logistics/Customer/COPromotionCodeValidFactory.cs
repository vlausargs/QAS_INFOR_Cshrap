//PROJECT NAME: Logistics
//CLASS NAME: COPromotionCodeValidFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class COPromotionCodeValidFactory
	{
		public ICOPromotionCodeValid Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _COPromotionCodeValid = new Logistics.Customer.COPromotionCodeValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCOPromotionCodeValidExt = timerfactory.Create<Logistics.Customer.ICOPromotionCodeValid>(_COPromotionCodeValid);
			
			return iCOPromotionCodeValidExt;
		}
	}
}
