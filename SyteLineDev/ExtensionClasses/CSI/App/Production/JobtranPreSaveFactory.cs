//PROJECT NAME: Production
//CLASS NAME: JobtranPreSaveFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class JobtranPreSaveFactory
	{
		public IJobtranPreSave Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _JobtranPreSave = new Production.JobtranPreSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJobtranPreSaveExt = timerfactory.Create<Production.IJobtranPreSave>(_JobtranPreSave);
			
			return iJobtranPreSaveExt;
		}
	}
}
