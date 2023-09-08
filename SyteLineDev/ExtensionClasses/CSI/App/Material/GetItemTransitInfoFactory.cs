//PROJECT NAME: Material
//CLASS NAME: GetItemTransitInfoFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class GetItemTransitInfoFactory
	{
		public IGetItemTransitInfo Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetItemTransitInfo = new Material.GetItemTransitInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetItemTransitInfoExt = timerfactory.Create<Material.IGetItemTransitInfo>(_GetItemTransitInfo);
			
			return iGetItemTransitInfoExt;
		}
	}
}
