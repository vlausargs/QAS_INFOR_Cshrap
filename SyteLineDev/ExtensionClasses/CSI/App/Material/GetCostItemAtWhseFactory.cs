//PROJECT NAME: Material
//CLASS NAME: GetCostItemAtWhseFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class GetCostItemAtWhseFactory
	{
		public IGetCostItemAtWhse Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetCostItemAtWhse = new Material.GetCostItemAtWhse(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetCostItemAtWhseExt = timerfactory.Create<Material.IGetCostItemAtWhse>(_GetCostItemAtWhse);
			
			return iGetCostItemAtWhseExt;
		}
	}
}
