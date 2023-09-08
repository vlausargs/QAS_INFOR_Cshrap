//PROJECT NAME: Production
//CLASS NAME: JobOperationsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class JobOperationsFactory
	{
		public IJobOperations Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _JobOperations = new Production.JobOperations(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJobOperationsExt = timerfactory.Create<Production.IJobOperations>(_JobOperations);
			
			return iJobOperationsExt;
		}
	}
}
