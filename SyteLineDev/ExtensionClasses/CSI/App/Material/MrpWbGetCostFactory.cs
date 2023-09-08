//PROJECT NAME: Material
//CLASS NAME: MrpWbGetCostFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class MrpWbGetCostFactory
	{
		public IMrpWbGetCost Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _MrpWbGetCost = new Material.MrpWbGetCost(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMrpWbGetCostExt = timerfactory.Create<Material.IMrpWbGetCost>(_MrpWbGetCost);
			
			return iMrpWbGetCostExt;
		}
	}
}
