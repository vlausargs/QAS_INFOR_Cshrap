//PROJECT NAME: Production
//CLASS NAME: RSQC_GetRcvrLocLotFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_GetRcvrLocLotFactory
	{
		public IRSQC_GetRcvrLocLot Create(IApplicationDB appDB)
		{
			var _RSQC_GetRcvrLocLot = new Production.Quality.RSQC_GetRcvrLocLot(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_GetRcvrLocLotExt = timerfactory.Create<Production.Quality.IRSQC_GetRcvrLocLot>(_RSQC_GetRcvrLocLot);
			
			return iRSQC_GetRcvrLocLotExt;
		}
	}
}
