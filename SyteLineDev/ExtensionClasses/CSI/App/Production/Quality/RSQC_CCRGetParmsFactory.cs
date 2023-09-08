//PROJECT NAME: Production
//CLASS NAME: RSQC_CCRGetParFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_CCRGetParFactory
	{
		public IRSQC_CCRGetPar Create(IApplicationDB appDB)
		{
			var _RSQC_CCRGetPar = new Production.Quality.RSQC_CCRGetPar(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_CCRGetParExt = timerfactory.Create<Production.Quality.IRSQC_CCRGetPar>(_RSQC_CCRGetPar);
			
			return iRSQC_CCRGetParExt;
		}
	}
}
