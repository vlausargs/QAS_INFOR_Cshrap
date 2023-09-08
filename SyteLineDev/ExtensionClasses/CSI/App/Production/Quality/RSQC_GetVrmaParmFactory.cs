//PROJECT NAME: Production
//CLASS NAME: RSQC_GetVrmaParmFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_GetVrmaParmFactory
	{
		public IRSQC_GetVrmaParm Create(IApplicationDB appDB)
		{
			var _RSQC_GetVrmaParm = new Production.Quality.RSQC_GetVrmaParm(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_GetVrmaParmExt = timerfactory.Create<Production.Quality.IRSQC_GetVrmaParm>(_RSQC_GetVrmaParm);
			
			return iRSQC_GetVrmaParmExt;
		}
	}
}
