//PROJECT NAME: Production
//CLASS NAME: RSQC_CreateQuickMrrFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_CreateQuickMrrFactory
	{
		public IRSQC_CreateQuickMrr Create(IApplicationDB appDB)
		{
			var _RSQC_CreateQuickMrr = new Production.Quality.RSQC_CreateQuickMrr(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_CreateQuickMrrExt = timerfactory.Create<Production.Quality.IRSQC_CreateQuickMrr>(_RSQC_CreateQuickMrr);
			
			return iRSQC_CreateQuickMrrExt;
		}
	}
}
