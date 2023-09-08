//PROJECT NAME: Production
//CLASS NAME: RSQC_CreateEachTestsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.Quality
{
	public class RSQC_CreateEachTestsFactory
	{
		public IRSQC_CreateEachTests Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _RSQC_CreateEachTests = new Production.Quality.RSQC_CreateEachTests(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_CreateEachTestsExt = timerfactory.Create<Production.Quality.IRSQC_CreateEachTests>(_RSQC_CreateEachTests);
			
			return iRSQC_CreateEachTestsExt;
		}
	}
}
