//PROJECT NAME: CSIProduct
//CLASS NAME: DelEopCostFactory.cs

using CSI.MG;

namespace CSI.Production
{
	public class DelEopCostFactory
	{
		public IDelEopCost Create(IApplicationDB appDB)
		{
			var _DelEopCost = new Production.DelEopCost(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDelEopCostExt = timerfactory.Create<Production.IDelEopCost>(_DelEopCost);
			
			return iDelEopCostExt;
		}
	}
}
