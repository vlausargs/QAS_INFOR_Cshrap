//PROJECT NAME: Logistics
//CLASS NAME: UpdateEstJobFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class UpdateEstJobFactory
	{
		public IUpdateEstJob Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _UpdateEstJob = new Logistics.Customer.UpdateEstJob(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iUpdateEstJobExt = timerfactory.Create<Logistics.Customer.IUpdateEstJob>(_UpdateEstJob);
			
			return iUpdateEstJobExt;
		}
	}
}
