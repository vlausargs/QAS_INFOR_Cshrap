//PROJECT NAME: Production
//CLASS NAME: RSQC_XRefVoucherFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.Quality
{
	public class RSQC_XRefVoucherFactory
	{
		public IRSQC_XRefVoucher Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _RSQC_XRefVoucher = new Production.Quality.RSQC_XRefVoucher(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_XRefVoucherExt = timerfactory.Create<Production.Quality.IRSQC_XRefVoucher>(_RSQC_XRefVoucher);
			
			return iRSQC_XRefVoucherExt;
		}
	}
}
