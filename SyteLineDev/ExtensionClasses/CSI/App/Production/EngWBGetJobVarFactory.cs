//PROJECT NAME: Production
//CLASS NAME: EngWBGetJobVarFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class EngWBGetJobVarFactory
	{
		public IEngWBGetJobVar Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _EngWBGetJobVar = new Production.EngWBGetJobVar(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEngWBGetJobVarExt = timerfactory.Create<Production.IEngWBGetJobVar>(_EngWBGetJobVar);
			
			return iEngWBGetJobVarExt;
		}
	}
}
