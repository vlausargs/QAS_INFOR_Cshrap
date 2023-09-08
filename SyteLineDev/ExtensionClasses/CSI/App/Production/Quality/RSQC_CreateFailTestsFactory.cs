//PROJECT NAME: Production
//CLASS NAME: RSQC_CreateFailTestsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.Quality
{
	public class RSQC_CreateFailTestsFactory
	{
		public IRSQC_CreateFailTests Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _RSQC_CreateFailTests = new Production.Quality.RSQC_CreateFailTests(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_CreateFailTestsExt = timerfactory.Create<Production.Quality.IRSQC_CreateFailTests>(_RSQC_CreateFailTests);
			
			return iRSQC_CreateFailTestsExt;
		}
	}
}
