//PROJECT NAME: Production
//CLASS NAME: RSQC_GetQuickMrrParmsFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_GetQuickMrrParmsFactory
	{
		public IRSQC_GetQuickMrrParms Create(IApplicationDB appDB)
		{
			var _RSQC_GetQuickMrrParms = new Production.Quality.RSQC_GetQuickMrrParms(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_GetQuickMrrParmsExt = timerfactory.Create<Production.Quality.IRSQC_GetQuickMrrParms>(_RSQC_GetQuickMrrParms);
			
			return iRSQC_GetQuickMrrParmsExt;
		}
	}
}
