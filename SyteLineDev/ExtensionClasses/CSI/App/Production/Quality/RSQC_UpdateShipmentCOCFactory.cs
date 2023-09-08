//PROJECT NAME: Production
//CLASS NAME: RSQC_UpdateShipmentCOCFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_UpdateShipmentCOCFactory
	{
		public IRSQC_UpdateShipmentCOC Create(IApplicationDB appDB)
		{
			var _RSQC_UpdateShipmentCOC = new Production.Quality.RSQC_UpdateShipmentCOC(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_UpdateShipmentCOCExt = timerfactory.Create<Production.Quality.IRSQC_UpdateShipmentCOC>(_RSQC_UpdateShipmentCOC);
			
			return iRSQC_UpdateShipmentCOCExt;
		}
	}
}
