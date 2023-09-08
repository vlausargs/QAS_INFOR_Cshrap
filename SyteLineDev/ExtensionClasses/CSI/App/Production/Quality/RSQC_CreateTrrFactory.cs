//PROJECT NAME: Production
//CLASS NAME: RSQC_CreateTrrFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_CreateTrrFactory
	{
		public IRSQC_CreateTrr Create(IApplicationDB appDB)
		{
			var _RSQC_CreateTrr = new Production.Quality.RSQC_CreateTrr(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_CreateTrrExt = timerfactory.Create<Production.Quality.IRSQC_CreateTrr>(_RSQC_CreateTrr);
			
			return iRSQC_CreateTrrExt;
		}
	}
}
