//PROJECT NAME: Employee
//CLASS NAME: EmployeeShiftSetFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Employee
{
	public class EmployeeShiftSetFactory
	{
		public IEmployeeShiftSet Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _EmployeeShiftSet = new Employee.EmployeeShiftSet(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEmployeeShiftSetExt = timerfactory.Create<Employee.IEmployeeShiftSet>(_EmployeeShiftSet);
			
			return iEmployeeShiftSetExt;
		}
	}
}
