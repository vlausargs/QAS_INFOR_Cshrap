//PROJECT NAME: Production
//CLASS NAME: RSQC_CreateDispositionEsigFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_CreateDispositionEsigFactory
	{
		public IRSQC_CreateDispositionEsig Create(IApplicationDB appDB)
		{
			var _RSQC_CreateDispositionEsig = new Production.Quality.RSQC_CreateDispositionEsig(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_CreateDispositionEsigExt = timerfactory.Create<Production.Quality.IRSQC_CreateDispositionEsig>(_RSQC_CreateDispositionEsig);
			
			return iRSQC_CreateDispositionEsigExt;
		}
	}
}
