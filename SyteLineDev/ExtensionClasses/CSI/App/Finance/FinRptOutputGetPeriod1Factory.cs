//PROJECT NAME: Finance
//CLASS NAME: FinRptOutputGetPeriod1Factory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class FinRptOutputGetPeriod1Factory
	{
		public IFinRptOutputGetPeriod1 Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _FinRptOutputGetPeriod1 = new Finance.FinRptOutputGetPeriod1(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFinRptOutputGetPeriod1Ext = timerfactory.Create<Finance.IFinRptOutputGetPeriod1>(_FinRptOutputGetPeriod1);
			
			return iFinRptOutputGetPeriod1Ext;
		}
	}
}
