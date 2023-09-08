//PROJECT NAME: Material
//CLASS NAME: CombineXferLocValidFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class CombineXferLocValidFactory
	{
		public ICombineXferLocValid Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CombineXferLocValid = new Material.CombineXferLocValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCombineXferLocValidExt = timerfactory.Create<Material.ICombineXferLocValid>(_CombineXferLocValid);
			
			return iCombineXferLocValidExt;
		}
	}
}
