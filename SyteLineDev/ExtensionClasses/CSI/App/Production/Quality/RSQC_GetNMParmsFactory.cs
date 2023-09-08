//PROJECT NAME: Production
//CLASS NAME: RSQC_GetNMParmsFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_GetNMParmsFactory
	{
		public IRSQC_GetNMParms Create(IApplicationDB appDB)
		{
			var _RSQC_GetNMParms = new Production.Quality.RSQC_GetNMParms(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_GetNMParmsExt = timerfactory.Create<Production.Quality.IRSQC_GetNMParms>(_RSQC_GetNMParms);
			
			return iRSQC_GetNMParmsExt;
		}
	}
}
