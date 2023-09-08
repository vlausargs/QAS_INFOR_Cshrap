//PROJECT NAME: Production
//CLASS NAME: RSQC_GageCheckFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_GageCheckFactory
	{
		public IRSQC_GageCheck Create(IApplicationDB appDB)
		{
			var _RSQC_GageCheck = new Production.Quality.RSQC_GageCheck(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_GageCheckExt = timerfactory.Create<Production.Quality.IRSQC_GageCheck>(_RSQC_GageCheck);
			
			return iRSQC_GageCheckExt;
		}
	}
}
