//PROJECT NAME: Finance
//CLASS NAME: PeriodsYTDFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class PeriodsYTDFactory
	{
		public IPeriodsYTD Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PeriodsYTD = new Finance.PeriodsYTD(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPeriodsYTDExt = timerfactory.Create<Finance.IPeriodsYTD>(_PeriodsYTD);
			
			return iPeriodsYTDExt;
		}
	}
}
