//PROJECT NAME: Production
//CLASS NAME: RSQC_GetTestDataFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.Quality
{
	public class RSQC_GetTestDataFactory
	{
		public IRSQC_GetTestData Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _RSQC_GetTestData = new Production.Quality.RSQC_GetTestData(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_GetTestDataExt = timerfactory.Create<Production.Quality.IRSQC_GetTestData>(_RSQC_GetTestData);
			
			return iRSQC_GetTestDataExt;
		}
	}
}
