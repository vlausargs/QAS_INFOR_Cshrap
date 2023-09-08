//PROJECT NAME: Finance
//CLASS NAME: FSBGetNextFiscalYearStartDateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class FSBGetNextFiscalYearStartDateFactory
	{
		public IFSBGetNextFiscalYearStartDate Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _FSBGetNextFiscalYearStartDate = new Finance.FSBGetNextFiscalYearStartDate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFSBGetNextFiscalYearStartDateExt = timerfactory.Create<Finance.IFSBGetNextFiscalYearStartDate>(_FSBGetNextFiscalYearStartDate);
			
			return iFSBGetNextFiscalYearStartDateExt;
		}
	}
}
