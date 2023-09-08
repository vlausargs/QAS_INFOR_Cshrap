//PROJECT NAME: Production
//CLASS NAME: PmfSpecUpdWipCostBomFactory.cs

using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfSpecUpdWipCostBomFactory
	{
		public IPmfSpecUpdWipCostBom Create(IApplicationDB appDB)
		{
			var _PmfSpecUpdWipCostBom = new Production.ProcessManufacturing.PmfSpecUpdWipCostBom(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfSpecUpdWipCostBomExt = timerfactory.Create<Production.ProcessManufacturing.IPmfSpecUpdWipCostBom>(_PmfSpecUpdWipCostBom);
			
			return iPmfSpecUpdWipCostBomExt;
		}
	}
}
