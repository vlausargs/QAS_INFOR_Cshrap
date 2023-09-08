//PROJECT NAME: Production
//CLASS NAME: RSQC_ShipUpdateCOCFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_ShipUpdateCOCFactory
	{
		public IRSQC_ShipUpdateCOC Create(IApplicationDB appDB)
		{
			var _RSQC_ShipUpdateCOC = new Production.Quality.RSQC_ShipUpdateCOC(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_ShipUpdateCOCExt = timerfactory.Create<Production.Quality.IRSQC_ShipUpdateCOC>(_RSQC_ShipUpdateCOC);
			
			return iRSQC_ShipUpdateCOCExt;
		}
	}
}
