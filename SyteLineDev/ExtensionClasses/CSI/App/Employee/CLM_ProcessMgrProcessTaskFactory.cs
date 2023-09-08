//PROJECT NAME: Employee
//CLASS NAME: CLM_ProcessMgrProcessTaskFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Employee
{
	public class CLM_ProcessMgrProcessTaskFactory
	{
		public ICLM_ProcessMgrProcessTask Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CLM_ProcessMgrProcessTask = new Employee.CLM_ProcessMgrProcessTask(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCLM_ProcessMgrProcessTaskExt = timerfactory.Create<Employee.ICLM_ProcessMgrProcessTask>(_CLM_ProcessMgrProcessTask);
			
			return iCLM_ProcessMgrProcessTaskExt;
		}
	}
}
