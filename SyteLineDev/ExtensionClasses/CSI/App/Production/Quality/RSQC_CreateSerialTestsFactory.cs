//PROJECT NAME: Production
//CLASS NAME: RSQC_CreateSerialTestsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.Quality
{
	public class RSQC_CreateSerialTestsFactory
	{
		public IRSQC_CreateSerialTests Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _RSQC_CreateSerialTests = new Production.Quality.RSQC_CreateSerialTests(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_CreateSerialTestsExt = timerfactory.Create<Production.Quality.IRSQC_CreateSerialTests>(_RSQC_CreateSerialTests);
			
			return iRSQC_CreateSerialTestsExt;
		}
	}
}
