//PROJECT NAME: Production
//CLASS NAME: RSQC_HomeAlertsFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_HomeAlertsFactory
	{
		public IRSQC_HomeAlerts Create(IApplicationDB appDB)
		{
			var _RSQC_HomeAlerts = new Production.Quality.RSQC_HomeAlerts(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_HomeAlertsExt = timerfactory.Create<Production.Quality.IRSQC_HomeAlerts>(_RSQC_HomeAlerts);
			
			return iRSQC_HomeAlertsExt;
		}
	}
}
