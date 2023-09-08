//PROJECT NAME: Production
//CLASS NAME: JobOrdersPreSaveFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class JobOrdersPreSaveFactory
	{
		public IJobOrdersPreSave Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _JobOrdersPreSave = new Production.JobOrdersPreSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJobOrdersPreSaveExt = timerfactory.Create<Production.IJobOrdersPreSave>(_JobOrdersPreSave);
			
			return iJobOrdersPreSaveExt;
		}
	}
}
