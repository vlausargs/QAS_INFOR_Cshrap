//PROJECT NAME: Finance
//CLASS NAME: GetJournalDefVarsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class GetJournalDefVarsFactory
	{
		public IGetJournalDefVars Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetJournalDefVars = new Finance.GetJournalDefVars(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetJournalDefVarsExt = timerfactory.Create<Finance.IGetJournalDefVars>(_GetJournalDefVars);
			
			return iGetJournalDefVarsExt;
		}
	}
}
