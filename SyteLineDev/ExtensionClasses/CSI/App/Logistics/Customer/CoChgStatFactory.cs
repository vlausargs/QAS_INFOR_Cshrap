//PROJECT NAME: Logistics
//CLASS NAME: CoChgStatFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class CoChgStatFactory
	{
		public ICoChgStat Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CoChgStat = new Logistics.Customer.CoChgStat(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCoChgStatExt = timerfactory.Create<Logistics.Customer.ICoChgStat>(_CoChgStat);
			
			return iCoChgStatExt;
		}
	}
}
