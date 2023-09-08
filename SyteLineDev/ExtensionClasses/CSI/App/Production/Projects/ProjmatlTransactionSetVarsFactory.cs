//PROJECT NAME: Production
//CLASS NAME: ProjmatlTransactionSetVarsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.Projects
{
	public class ProjmatlTransactionSetVarsFactory
	{
		public IProjmatlTransactionSetVars Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ProjmatlTransactionSetVars = new Production.Projects.ProjmatlTransactionSetVars(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProjmatlTransactionSetVarsExt = timerfactory.Create<Production.Projects.IProjmatlTransactionSetVars>(_ProjmatlTransactionSetVars);
			
			return iProjmatlTransactionSetVarsExt;
		}
	}
}
