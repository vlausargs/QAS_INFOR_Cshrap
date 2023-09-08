//PROJECT NAME: Material
//CLASS NAME: BolItemSetGloVarFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class BolItemSetGloVarFactory
	{
		public IBolItemSetGloVar Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _BolItemSetGloVar = new Material.BolItemSetGloVar(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iBolItemSetGloVarExt = timerfactory.Create<Material.IBolItemSetGloVar>(_BolItemSetGloVar);
			
			return iBolItemSetGloVarExt;
		}
	}
}
