//PROJECT NAME: Finance
//CLASS NAME: GetFirstFiscalYearFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class GetFirstFiscalYearFactory
	{
		public IGetFirstFiscalYear Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetFirstFiscalYear = new Finance.GetFirstFiscalYear(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetFirstFiscalYearExt = timerfactory.Create<Finance.IGetFirstFiscalYear>(_GetFirstFiscalYear);
			
			return iGetFirstFiscalYearExt;
		}
	}
}
