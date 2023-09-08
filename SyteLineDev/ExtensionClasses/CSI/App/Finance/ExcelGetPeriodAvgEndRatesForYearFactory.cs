//PROJECT NAME: Finance
//CLASS NAME: ExcelGetPeriodAvgEndRatesForYearFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class ExcelGetPeriodAvgEndRatesForYearFactory
	{
		public IExcelGetPeriodAvgEndRatesForYear Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;
			var parameterProvider = cSIExtensionClassBase.ParameterProvider;
			var mgInvoker = cSIExtensionClassBase.MGInvoker;
			
			var _ExcelGetPeriodAvgEndRatesForYear = new Finance.ExcelGetPeriodAvgEndRatesForYear(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iExcelGetPeriodAvgEndRatesForYearExt = timerfactory.Create<Finance.IExcelGetPeriodAvgEndRatesForYear>(_ExcelGetPeriodAvgEndRatesForYear);
			
			return iExcelGetPeriodAvgEndRatesForYearExt;
		}
	}
}
