//PROJECT NAME: Production
//CLASS NAME: RSQC_CreateBatchTestsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.Quality
{
	public class RSQC_CreateBatchTestsFactory
	{
		public IRSQC_CreateBatchTests Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _RSQC_CreateBatchTests = new Production.Quality.RSQC_CreateBatchTests(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_CreateBatchTestsExt = timerfactory.Create<Production.Quality.IRSQC_CreateBatchTests>(_RSQC_CreateBatchTests);
			
			return iRSQC_CreateBatchTestsExt;
		}
	}
}
