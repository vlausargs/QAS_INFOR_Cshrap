//PROJECT NAME: Production
//CLASS NAME: RSQC_DeletetmpserFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_DeletetmpserFactory
	{
		public IRSQC_Deletetmpser Create(IApplicationDB appDB)
		{
			var _RSQC_Deletetmpser = new Production.Quality.RSQC_Deletetmpser(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_DeletetmpserExt = timerfactory.Create<Production.Quality.IRSQC_Deletetmpser>(_RSQC_Deletetmpser);
			
			return iRSQC_DeletetmpserExt;
		}
	}
}
