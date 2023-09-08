//PROJECT NAME: Material
//CLASS NAME: CopyCostingAnalysisAlternativeRoutingFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class CopyCostingAnalysisAlternativeRoutingFactory
	{
		public ICopyCostingAnalysisAlternativeRouting Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CopyCostingAnalysisAlternativeRouting = new Material.CopyCostingAnalysisAlternativeRouting(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCopyCostingAnalysisAlternativeRoutingExt = timerfactory.Create<Material.ICopyCostingAnalysisAlternativeRouting>(_CopyCostingAnalysisAlternativeRouting);
			
			return iCopyCostingAnalysisAlternativeRoutingExt;
		}
	}
}
