//PROJECT NAME: Production
//CLASS NAME: RSQC_PostDispositionFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.Quality
{
	public class RSQC_PostDispositionFactory
	{
		public IRSQC_PostDisposition Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _RSQC_PostDisposition = new Production.Quality.RSQC_PostDisposition(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_PostDispositionExt = timerfactory.Create<Production.Quality.IRSQC_PostDisposition>(_RSQC_PostDisposition);
			
			return iRSQC_PostDispositionExt;
		}
	}
}
