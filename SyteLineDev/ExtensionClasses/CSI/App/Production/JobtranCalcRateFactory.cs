//PROJECT NAME: Production
//CLASS NAME: JobtranCalcRateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class JobtranCalcRateFactory
	{
		public IJobtranCalcRate Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _JobtranCalcRate = new Production.JobtranCalcRate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJobtranCalcRateExt = timerfactory.Create<Production.IJobtranCalcRate>(_JobtranCalcRate);
			
			return iJobtranCalcRateExt;
		}
	}
}
