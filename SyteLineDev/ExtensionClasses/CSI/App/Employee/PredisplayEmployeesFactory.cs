//PROJECT NAME: Employee
//CLASS NAME: PredisplayEmployeesFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Employee
{
	public class PredisplayEmployeesFactory
	{
		public IPredisplayEmployees Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PredisplayEmployees = new Employee.PredisplayEmployees(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPredisplayEmployeesExt = timerfactory.Create<Employee.IPredisplayEmployees>(_PredisplayEmployees);
			
			return iPredisplayEmployeesExt;
		}
	}
}
