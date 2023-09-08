//PROJECT NAME: Production
//CLASS NAME: RSQC_CopyTestsFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_CopyTestsFactory
	{
		public IRSQC_CopyTests Create(IApplicationDB appDB)
		{
			var _RSQC_CopyTests = new Production.Quality.RSQC_CopyTests(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_CopyTestsExt = timerfactory.Create<Production.Quality.IRSQC_CopyTests>(_RSQC_CopyTests);
			
			return iRSQC_CopyTestsExt;
		}
	}
}
