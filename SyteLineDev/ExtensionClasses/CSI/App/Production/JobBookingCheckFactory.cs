//PROJECT NAME: Production
//CLASS NAME: JobBookingCheckFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class JobBookingCheckFactory
	{
		public IJobBookingCheck Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _JobBookingCheck = new Production.JobBookingCheck(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJobBookingCheckExt = timerfactory.Create<Production.IJobBookingCheck>(_JobBookingCheck);
			
			return iJobBookingCheckExt;
		}
	}
}
