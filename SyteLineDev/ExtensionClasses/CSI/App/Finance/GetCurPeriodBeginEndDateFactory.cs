//PROJECT NAME: Finance
//CLASS NAME: GetCurPeriodBeginEndDateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class GetCurPeriodBeginEndDateFactory
	{
		public IGetCurPeriodBeginEndDate Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetCurPeriodBeginEndDate = new Finance.GetCurPeriodBeginEndDate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetCurPeriodBeginEndDateExt = timerfactory.Create<Finance.IGetCurPeriodBeginEndDate>(_GetCurPeriodBeginEndDate);
			
			return iGetCurPeriodBeginEndDateExt;
		}
	}
}
