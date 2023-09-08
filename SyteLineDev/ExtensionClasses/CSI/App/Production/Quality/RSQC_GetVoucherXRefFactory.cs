//PROJECT NAME: Production
//CLASS NAME: RSQC_GetVoucherXRefFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_GetVoucherXRefFactory
	{
		public IRSQC_GetVoucherXRef Create(IApplicationDB appDB)
		{
			var _RSQC_GetVoucherXRef = new Production.Quality.RSQC_GetVoucherXRef(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_GetVoucherXRefExt = timerfactory.Create<Production.Quality.IRSQC_GetVoucherXRef>(_RSQC_GetVoucherXRef);
			
			return iRSQC_GetVoucherXRefExt;
		}
	}
}
