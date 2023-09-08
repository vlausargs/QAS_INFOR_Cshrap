//PROJECT NAME: Employee
//CLASS NAME: Rpt_EmployeeHoursFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Employee
{
	public class Rpt_EmployeeHoursFactory
	{
		public IRpt_EmployeeHours Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_EmployeeHours = new Employee.Rpt_EmployeeHours(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_EmployeeHoursExt = timerfactory.Create<Employee.IRpt_EmployeeHours>(_Rpt_EmployeeHours);
			
			return iRpt_EmployeeHoursExt;
		}
	}
}
