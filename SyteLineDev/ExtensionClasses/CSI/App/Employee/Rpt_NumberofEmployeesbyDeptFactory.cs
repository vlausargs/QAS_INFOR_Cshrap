//PROJECT NAME: Employee
//CLASS NAME: Rpt_NumberofEmployeesbyDeptFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Employee
{
	public class Rpt_NumberofEmployeesbyDeptFactory
	{
		public IRpt_NumberofEmployeesbyDept Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_NumberofEmployeesbyDept = new Employee.Rpt_NumberofEmployeesbyDept(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_NumberofEmployeesbyDeptExt = timerfactory.Create<Employee.IRpt_NumberofEmployeesbyDept>(_Rpt_NumberofEmployeesbyDept);
			
			return iRpt_NumberofEmployeesbyDeptExt;
		}
	}
}
