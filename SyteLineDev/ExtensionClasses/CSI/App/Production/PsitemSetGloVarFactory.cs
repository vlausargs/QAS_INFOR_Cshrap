//PROJECT NAME: Production
//CLASS NAME: PsitemSetGloVarFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class PsitemSetGloVarFactory
	{
		public IPsitemSetGloVar Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PsitemSetGloVar = new Production.PsitemSetGloVar(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPsitemSetGloVarExt = timerfactory.Create<Production.IPsitemSetGloVar>(_PsitemSetGloVar);
			
			return iPsitemSetGloVarExt;
		}
	}
}
