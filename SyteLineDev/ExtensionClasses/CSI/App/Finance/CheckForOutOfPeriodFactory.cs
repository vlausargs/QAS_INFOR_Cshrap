//PROJECT NAME: Finance
//CLASS NAME: CheckForOutOfPeriodFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class CheckForOutOfPeriodFactory
	{
		public ICheckForOutOfPeriod Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CheckForOutOfPeriod = new Finance.CheckForOutOfPeriod(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCheckForOutOfPeriodExt = timerfactory.Create<Finance.ICheckForOutOfPeriod>(_CheckForOutOfPeriod);
			
			return iCheckForOutOfPeriodExt;
		}
	}
}
