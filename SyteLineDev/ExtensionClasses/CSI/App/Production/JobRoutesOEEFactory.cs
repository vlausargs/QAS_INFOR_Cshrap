//PROJECT NAME: Production
//CLASS NAME: JobRoutesOEEFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class JobRoutesOEEFactory
	{
		public IJobRoutesOEE Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _JobRoutesOEE = new Production.JobRoutesOEE(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJobRoutesOEEExt = timerfactory.Create<Production.IJobRoutesOEE>(_JobRoutesOEE);
			
			return iJobRoutesOEEExt;
		}
	}
}
