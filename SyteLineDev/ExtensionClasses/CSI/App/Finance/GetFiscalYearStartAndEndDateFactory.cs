//PROJECT NAME: Finance
//CLASS NAME: GetFiscalYearStartAndEndDateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class GetFiscalYearStartAndEndDateFactory
	{
		public IGetFiscalYearStartAndEndDate Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetFiscalYearStartAndEndDate = new Finance.GetFiscalYearStartAndEndDate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetFiscalYearStartAndEndDateExt = timerfactory.Create<Finance.IGetFiscalYearStartAndEndDate>(_GetFiscalYearStartAndEndDate);
			
			return iGetFiscalYearStartAndEndDateExt;
		}
	}
}
