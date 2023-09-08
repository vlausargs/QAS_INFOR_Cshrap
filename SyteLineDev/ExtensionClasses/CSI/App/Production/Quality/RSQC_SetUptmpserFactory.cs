//PROJECT NAME: Production
//CLASS NAME: RSQC_SetUptmpserFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_SetUptmpserFactory
	{
		public IRSQC_SetUptmpser Create(IApplicationDB appDB)
		{
			var _RSQC_SetUptmpser = new Production.Quality.RSQC_SetUptmpser(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_SetUptmpserExt = timerfactory.Create<Production.Quality.IRSQC_SetUptmpser>(_RSQC_SetUptmpser);
			
			return iRSQC_SetUptmpserExt;
		}
	}
}
