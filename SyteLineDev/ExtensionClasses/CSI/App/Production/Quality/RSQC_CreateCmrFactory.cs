//PROJECT NAME: Production
//CLASS NAME: RSQC_CreateCmrFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_CreateCmrFactory
	{
		public IRSQC_CreateCmr Create(IApplicationDB appDB)
		{
			var _RSQC_CreateCmr = new Production.Quality.RSQC_CreateCmr(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_CreateCmrExt = timerfactory.Create<Production.Quality.IRSQC_CreateCmr>(_RSQC_CreateCmr);
			
			return iRSQC_CreateCmrExt;
		}
	}
}
