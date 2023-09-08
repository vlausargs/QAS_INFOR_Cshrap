//PROJECT NAME: Employee
//CLASS NAME: EmployeesPostQueryFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Employee
{
	public class EmployeesPostQueryFactory
	{
		public IEmployeesPostQuery Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _EmployeesPostQuery = new Employee.EmployeesPostQuery(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEmployeesPostQueryExt = timerfactory.Create<Employee.IEmployeesPostQuery>(_EmployeesPostQuery);
			
			return iEmployeesPostQueryExt;
		}
	}
}
