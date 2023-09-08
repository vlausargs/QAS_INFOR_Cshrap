//PROJECT NAME: Production
//CLASS NAME: RSQC_GetEmailParmsFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_GetEmailParmsFactory
	{
		public IRSQC_GetEmailParms Create(IApplicationDB appDB)
		{
			var _RSQC_GetEmailParms = new Production.Quality.RSQC_GetEmailParms(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_GetEmailParmsExt = timerfactory.Create<Production.Quality.IRSQC_GetEmailParms>(_RSQC_GetEmailParms);
			
			return iRSQC_GetEmailParmsExt;
		}
	}
}
