//PROJECT NAME: Production
//CLASS NAME: RSQC_SetUnitCostFactory.cs

using CSI.MG;

namespace CSI.Production.Quality
{
	public class RSQC_SetUnitCostFactory
	{
		public IRSQC_SetUnitCost Create(IApplicationDB appDB)
		{
			var _RSQC_SetUnitCost = new Production.Quality.RSQC_SetUnitCost(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRSQC_SetUnitCostExt = timerfactory.Create<Production.Quality.IRSQC_SetUnitCost>(_RSQC_SetUnitCost);
			
			return iRSQC_SetUnitCostExt;
		}
	}
}
