//PROJECT NAME: Production
//CLASS NAME: RSQC_GetItemhAlertsFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_GetItemhAlertsFactory
	{
		public IRSQC_GetItemhAlerts Create(IApplicationDB appDB)
		{
			var _RSQC_GetItemhAlerts = new Production.Quality.RSQC_GetItemhAlerts(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_GetItemhAlertsExt = timerfactory.Create<Production.Quality.IRSQC_GetItemhAlerts>(_RSQC_GetItemhAlerts);
			
			return iRSQC_GetItemhAlertsExt;
		}
	}
}
