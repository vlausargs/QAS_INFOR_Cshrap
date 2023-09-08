//PROJECT NAME: Production
//CLASS NAME: RSQC_PreDispositionFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_PreDispositionFactory
	{
		public IRSQC_PreDisposition Create(IApplicationDB appDB)
		{
			var _RSQC_PreDisposition = new Production.Quality.RSQC_PreDisposition(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_PreDispositionExt = timerfactory.Create<Production.Quality.IRSQC_PreDisposition>(_RSQC_PreDisposition);
			
			return iRSQC_PreDispositionExt;
		}
	}
}
