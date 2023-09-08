//PROJECT NAME: Production
//CLASS NAME: RSQC_CheckTestsFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_CheckTestsFactory
	{
		public IRSQC_CheckTests Create(IApplicationDB appDB)
		{
			var _RSQC_CheckTests = new Production.Quality.RSQC_CheckTests(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_CheckTestsExt = timerfactory.Create<Production.Quality.IRSQC_CheckTests>(_RSQC_CheckTests);
			
			return iRSQC_CheckTestsExt;
		}
	}
}
