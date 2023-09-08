//PROJECT NAME: Production
//CLASS NAME: RSQC_CanClosePhaseFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_CanClosePhaseFactory
	{
		public IRSQC_CanClosePhase Create(IApplicationDB appDB)
		{
			var _RSQC_CanClosePhase = new Production.Quality.RSQC_CanClosePhase(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_CanClosePhaseExt = timerfactory.Create<Production.Quality.IRSQC_CanClosePhase>(_RSQC_CanClosePhase);
			
			return iRSQC_CanClosePhaseExt;
		}
	}
}
