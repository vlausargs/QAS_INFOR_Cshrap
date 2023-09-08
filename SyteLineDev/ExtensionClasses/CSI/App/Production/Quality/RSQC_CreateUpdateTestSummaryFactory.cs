//PROJECT NAME: Production
//CLASS NAME: RSQC_CreateUpdateTestSummaryFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.Quality
{
	public class RSQC_CreateUpdateTestSummaryFactory
	{
		public IRSQC_CreateUpdateTestSummary Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _RSQC_CreateUpdateTestSummary = new Production.Quality.RSQC_CreateUpdateTestSummary(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_CreateUpdateTestSummaryExt = timerfactory.Create<Production.Quality.IRSQC_CreateUpdateTestSummary>(_RSQC_CreateUpdateTestSummary);
			
			return iRSQC_CreateUpdateTestSummaryExt;
		}
	}
}
