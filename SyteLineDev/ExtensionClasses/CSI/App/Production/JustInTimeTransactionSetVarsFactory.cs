//PROJECT NAME: Production
//CLASS NAME: JustInTimeTransactionSetVarsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class JustInTimeTransactionSetVarsFactory
	{
		public IJustInTimeTransactionSetVars Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _JustInTimeTransactionSetVars = new Production.JustInTimeTransactionSetVars(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJustInTimeTransactionSetVarsExt = timerfactory.Create<Production.IJustInTimeTransactionSetVars>(_JustInTimeTransactionSetVars);
			
			return iJustInTimeTransactionSetVarsExt;
		}
	}
}
