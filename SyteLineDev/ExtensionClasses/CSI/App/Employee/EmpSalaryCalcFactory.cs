//PROJECT NAME: Employee
//CLASS NAME: EmpSalaryCalcFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Employee
{
	public class EmpSalaryCalcFactory
	{
		public IEmpSalaryCalc Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _EmpSalaryCalc = new Employee.EmpSalaryCalc(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEmpSalaryCalcExt = timerfactory.Create<Employee.IEmpSalaryCalc>(_EmpSalaryCalc);
			
			return iEmpSalaryCalcExt;
		}
	}
}
