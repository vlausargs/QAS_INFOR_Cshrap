//PROJECT NAME: Finance
//CLASS NAME: FSBGetDescriptionByPeriodFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class FSBGetDescriptionByPeriodFactory
	{
		public IFSBGetDescriptionByPeriod Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _FSBGetDescriptionByPeriod = new Finance.FSBGetDescriptionByPeriod(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFSBGetDescriptionByPeriodExt = timerfactory.Create<Finance.IFSBGetDescriptionByPeriod>(_FSBGetDescriptionByPeriod);
			
			return iFSBGetDescriptionByPeriodExt;
		}
	}
}
