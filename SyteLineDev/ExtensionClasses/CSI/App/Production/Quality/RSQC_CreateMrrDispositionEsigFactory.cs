//PROJECT NAME: Production
//CLASS NAME: RSQC_CreateMrrDispositionEsigFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_CreateMrrDispositionEsigFactory
	{
		public IRSQC_CreateMrrDispositionEsig Create(IApplicationDB appDB)
		{
			var _RSQC_CreateMrrDispositionEsig = new Production.Quality.RSQC_CreateMrrDispositionEsig(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_CreateMrrDispositionEsigExt = timerfactory.Create<Production.Quality.IRSQC_CreateMrrDispositionEsig>(_RSQC_CreateMrrDispositionEsig);
			
			return iRSQC_CreateMrrDispositionEsigExt;
		}
	}
}
