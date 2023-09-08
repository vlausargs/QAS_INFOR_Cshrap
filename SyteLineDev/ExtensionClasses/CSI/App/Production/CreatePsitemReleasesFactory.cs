//PROJECT NAME: Production
//CLASS NAME: CreatePsitemReleasesFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class CreatePsitemReleasesFactory
	{
		public ICreatePsitemReleases Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CreatePsitemReleases = new Production.CreatePsitemReleases(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCreatePsitemReleasesExt = timerfactory.Create<Production.ICreatePsitemReleases>(_CreatePsitemReleases);
			
			return iCreatePsitemReleasesExt;
		}
	}
}
