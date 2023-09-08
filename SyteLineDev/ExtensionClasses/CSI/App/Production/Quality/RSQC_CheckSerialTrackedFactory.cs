//PROJECT NAME: Production
//CLASS NAME: RSQC_CheckSerialTrackedFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_CheckSerialTrackedFactory
	{
		public IRSQC_CheckSerialTracked Create(IApplicationDB appDB)
		{
			var _RSQC_CheckSerialTracked = new Production.Quality.RSQC_CheckSerialTracked(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_CheckSerialTrackedExt = timerfactory.Create<Production.Quality.IRSQC_CheckSerialTracked>(_RSQC_CheckSerialTracked);
			
			return iRSQC_CheckSerialTrackedExt;
		}
	}
}
