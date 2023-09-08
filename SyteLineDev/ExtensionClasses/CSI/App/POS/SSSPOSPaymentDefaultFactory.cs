//PROJECT NAME: POS
//CLASS NAME: SSSPOSPaymentDefaultFactory.cs

using CSI.MG;

namespace CSI.POS
{
	public class SSSPOSPaymentDefaultFactory
	{
		public ISSSPOSPaymentDefault Create(IApplicationDB appDB)
		{
			var _SSSPOSPaymentDefault = new POS.SSSPOSPaymentDefault(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSPOSPaymentDefaultExt = timerfactory.Create<POS.ISSSPOSPaymentDefault>(_SSSPOSPaymentDefault);
			
			return iSSSPOSPaymentDefaultExt;
		}
	}
}
