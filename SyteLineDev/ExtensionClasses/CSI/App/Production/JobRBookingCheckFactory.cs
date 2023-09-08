//PROJECT NAME: Production
//CLASS NAME: JobRBookingCheckFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class JobRBookingCheckFactory
	{
		public IJobRBookingCheck Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _JobRBookingCheck = new Production.JobRBookingCheck(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJobRBookingCheckExt = timerfactory.Create<Production.IJobRBookingCheck>(_JobRBookingCheck);
			
			return iJobRBookingCheckExt;
		}
	}
}
