//PROJECT NAME: Employee
//CLASS NAME: ProcessMgrAssignToFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Employee
{
	public class ProcessMgrAssignToFactory
	{
		public IProcessMgrAssignTo Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _ProcessMgrAssignTo = new Employee.ProcessMgrAssignTo(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iProcessMgrAssignToExt = timerfactory.Create<Employee.IProcessMgrAssignTo>(_ProcessMgrAssignTo);
			
			return iProcessMgrAssignToExt;
		}
	}
}
