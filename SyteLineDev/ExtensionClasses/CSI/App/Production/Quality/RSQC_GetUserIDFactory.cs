//PROJECT NAME: Production
//CLASS NAME: RSQC_GetUserIDFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_GetUserIDFactory
	{
		public IRSQC_GetUserID Create(IApplicationDB appDB)
		{
			var _RSQC_GetUserID = new Production.Quality.RSQC_GetUserID(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_GetUserIDExt = timerfactory.Create<Production.Quality.IRSQC_GetUserID>(_RSQC_GetUserID);
			
			return iRSQC_GetUserIDExt;
		}
	}
}
