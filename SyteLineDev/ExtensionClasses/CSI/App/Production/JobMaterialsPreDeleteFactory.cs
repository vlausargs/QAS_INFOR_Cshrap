//PROJECT NAME: Production
//CLASS NAME: JobMaterialsPreDeleteFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class JobMaterialsPreDeleteFactory
	{
		public IJobMaterialsPreDelete Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _JobMaterialsPreDelete = new Production.JobMaterialsPreDelete(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJobMaterialsPreDeleteExt = timerfactory.Create<Production.IJobMaterialsPreDelete>(_JobMaterialsPreDelete);
			
			return iJobMaterialsPreDeleteExt;
		}
	}
}
