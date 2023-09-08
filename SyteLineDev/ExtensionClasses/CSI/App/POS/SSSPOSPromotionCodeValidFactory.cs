//PROJECT NAME: POS
//CLASS NAME: SSSPOSPromotionCodeValidFactory.cs

using CSI.MG;

namespace CSI.POS
{
	public class SSSPOSPromotionCodeValidFactory
	{
		public ISSSPOSPromotionCodeValid Create(IApplicationDB appDB)
		{
			var _SSSPOSPromotionCodeValid = new POS.SSSPOSPromotionCodeValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSPOSPromotionCodeValidExt = timerfactory.Create<POS.ISSSPOSPromotionCodeValid>(_SSSPOSPromotionCodeValid);
			
			return iSSSPOSPromotionCodeValidExt;
		}
	}
}
