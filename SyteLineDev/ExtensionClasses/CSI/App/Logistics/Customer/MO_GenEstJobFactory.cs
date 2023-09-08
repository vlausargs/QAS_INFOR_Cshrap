//PROJECT NAME: Logistics
//CLASS NAME: MO_GenEstJobFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class MO_GenEstJobFactory
	{
		public IMO_GenEstJob Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _MO_GenEstJob = new Logistics.Customer.MO_GenEstJob(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMO_GenEstJobExt = timerfactory.Create<Logistics.Customer.IMO_GenEstJob>(_MO_GenEstJob);
			
			return iMO_GenEstJobExt;
		}
	}
}
