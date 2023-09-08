//PROJECT NAME: Production
//CLASS NAME: JobtranPostSaveFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class JobtranPostSaveFactory
	{
		public IJobtranPostSave Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _JobtranPostSave = new Production.JobtranPostSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJobtranPostSaveExt = timerfactory.Create<Production.IJobtranPostSave>(_JobtranPostSave);
			
			return iJobtranPostSaveExt;
		}
	}
}
