//PROJECT NAME: Production
//CLASS NAME: PmfFmUpdWipCostBomFactory.cs

using CSI.MG;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfFmUpdWipCostBomFactory
	{
		public IPmfFmUpdWipCostBom Create(IApplicationDB appDB)
		{
			var _PmfFmUpdWipCostBom = new Production.ProcessManufacturing.PmfFmUpdWipCostBom(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfFmUpdWipCostBomExt = timerfactory.Create<Production.ProcessManufacturing.IPmfFmUpdWipCostBom>(_PmfFmUpdWipCostBom);
			
			return iPmfFmUpdWipCostBomExt;
		}
	}
}
