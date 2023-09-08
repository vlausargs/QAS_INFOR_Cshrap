//PROJECT NAME: Production
//CLASS NAME: RSQC_GetQCItemRowidFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_GetQCItemRowidFactory
	{
		public IRSQC_GetQCItemRowid Create(IApplicationDB appDB)
		{
			var _RSQC_GetQCItemRowid = new Production.Quality.RSQC_GetQCItemRowid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_GetQCItemRowidExt = timerfactory.Create<Production.Quality.IRSQC_GetQCItemRowid>(_RSQC_GetQCItemRowid);
			
			return iRSQC_GetQCItemRowidExt;
		}
	}
}
