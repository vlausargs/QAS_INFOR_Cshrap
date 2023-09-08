//PROJECT NAME: Employee
//CLASS NAME: EmpRetPlanEligibleFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Employee
{
	public class EmpRetPlanEligibleFactory
	{
		public IEmpRetPlanEligible Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _EmpRetPlanEligible = new Employee.EmpRetPlanEligible(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iEmpRetPlanEligibleExt = timerfactory.Create<Employee.IEmpRetPlanEligible>(_EmpRetPlanEligible);
			
			return iEmpRetPlanEligibleExt;
		}
	}
}
