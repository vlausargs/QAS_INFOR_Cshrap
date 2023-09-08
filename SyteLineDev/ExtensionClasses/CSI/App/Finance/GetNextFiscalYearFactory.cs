//PROJECT NAME: Finance
//CLASS NAME: GetNextFiscalYearFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class GetNextFiscalYearFactory
	{
		public IGetNextFiscalYear Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetNextFiscalYear = new Finance.GetNextFiscalYear(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetNextFiscalYearExt = timerfactory.Create<Finance.IGetNextFiscalYear>(_GetNextFiscalYear);
			
			return iGetNextFiscalYearExt;
		}
	}
}
