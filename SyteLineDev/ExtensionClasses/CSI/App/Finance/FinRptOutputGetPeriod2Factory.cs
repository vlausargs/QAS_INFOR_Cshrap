//PROJECT NAME: Finance
//CLASS NAME: FinRptOutputGetPeriod2Factory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class FinRptOutputGetPeriod2Factory
	{
		public IFinRptOutputGetPeriod2 Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _FinRptOutputGetPeriod2 = new Finance.FinRptOutputGetPeriod2(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFinRptOutputGetPeriod2Ext = timerfactory.Create<Finance.IFinRptOutputGetPeriod2>(_FinRptOutputGetPeriod2);
			
			return iFinRptOutputGetPeriod2Ext;
		}
	}
}
