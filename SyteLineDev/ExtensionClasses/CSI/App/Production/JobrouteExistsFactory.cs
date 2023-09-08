//PROJECT NAME: Production
//CLASS NAME: JobrouteExistsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class JobrouteExistsFactory
	{
		public IJobrouteExists Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _JobrouteExists = new Production.JobrouteExists(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJobrouteExistsExt = timerfactory.Create<Production.IJobrouteExists>(_JobrouteExists);
			
			return iJobrouteExistsExt;
		}
	}
}
