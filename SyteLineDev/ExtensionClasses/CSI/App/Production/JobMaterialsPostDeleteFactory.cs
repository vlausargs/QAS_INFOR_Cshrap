//PROJECT NAME: Production
//CLASS NAME: JobMaterialsPostDeleteFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class JobMaterialsPostDeleteFactory
	{
		public IJobMaterialsPostDelete Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _JobMaterialsPostDelete = new Production.JobMaterialsPostDelete(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJobMaterialsPostDeleteExt = timerfactory.Create<Production.IJobMaterialsPostDelete>(_JobMaterialsPostDelete);
			
			return iJobMaterialsPostDeleteExt;
		}
	}
}
