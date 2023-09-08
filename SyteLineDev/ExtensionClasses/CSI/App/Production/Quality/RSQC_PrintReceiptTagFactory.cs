//PROJECT NAME: Production
//CLASS NAME: RSQC_PrintReceiptTagFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.Quality
{
	public class RSQC_PrintReceiptTagFactory
	{
		public IRSQC_PrintReceiptTag Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _RSQC_PrintReceiptTag = new Production.Quality.RSQC_PrintReceiptTag(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_PrintReceiptTagExt = timerfactory.Create<Production.Quality.IRSQC_PrintReceiptTag>(_RSQC_PrintReceiptTag);
			
			return iRSQC_PrintReceiptTagExt;
		}
	}
}
