//PROJECT NAME: Production
//CLASS NAME: RSQC_ShipCleanupCOCFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_ShipCleanupCOCFactory
	{
		public IRSQC_ShipCleanupCOC Create(IApplicationDB appDB)
		{
			var _RSQC_ShipCleanupCOC = new Production.Quality.RSQC_ShipCleanupCOC(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_ShipCleanupCOCExt = timerfactory.Create<Production.Quality.IRSQC_ShipCleanupCOC>(_RSQC_ShipCleanupCOC);
			
			return iRSQC_ShipCleanupCOCExt;
		}
	}
}
