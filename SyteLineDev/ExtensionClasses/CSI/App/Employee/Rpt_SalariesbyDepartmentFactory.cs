//PROJECT NAME: Employee
//CLASS NAME: Rpt_SalariesbyDepartmentFactory.cs

using CSI.MG;
using CSI.Data.SQL;
using CSI.Data.RecordSets;

namespace CSI.Employee
{
	public class Rpt_SalariesbyDepartmentFactory
	{
		public IRpt_SalariesbyDepartment Create(IApplicationDB appDB,
		IBunchedLoadCollection bunchedLoadCollection,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_SalariesbyDepartment = new Employee.Rpt_SalariesbyDepartment(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_SalariesbyDepartmentExt = timerfactory.Create<Employee.IRpt_SalariesbyDepartment>(_Rpt_SalariesbyDepartment);
			
			return iRpt_SalariesbyDepartmentExt;
		}
	}
}
