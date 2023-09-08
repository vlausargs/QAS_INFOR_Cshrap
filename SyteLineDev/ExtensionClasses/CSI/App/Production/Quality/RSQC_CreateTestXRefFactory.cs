//PROJECT NAME: Production
//CLASS NAME: RSQC_CreateTestXRefFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.Quality
{
	public class RSQC_CreateTestXRefFactory
	{
		public IRSQC_CreateTestXRef Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _RSQC_CreateTestXRef = new Production.Quality.RSQC_CreateTestXRef(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_CreateTestXRefExt = timerfactory.Create<Production.Quality.IRSQC_CreateTestXRef>(_RSQC_CreateTestXRef);
			
			return iRSQC_CreateTestXRefExt;
		}
	}
}
