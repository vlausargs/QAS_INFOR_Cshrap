//PROJECT NAME: Material
//CLASS NAME: IaPostSetVarsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class IaPostSetVarsFactory
	{
		public IIaPostSetVars Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _IaPostSetVars = new Material.IaPostSetVars(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iIaPostSetVarsExt = timerfactory.Create<Material.IIaPostSetVars>(_IaPostSetVars);
			
			return iIaPostSetVarsExt;
		}
	}
}
