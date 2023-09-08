//PROJECT NAME: Employee
//CLASS NAME: RequirementValidFactory.cs

using CSI.MG;

namespace CSI.Employee
{
	public class RequirementValidFactory
	{
		public IRequirementValid Create(IApplicationDB appDB)
		{
			var _RequirementValid = new Employee.RequirementValid(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRequirementValidExt = timerfactory.Create<Employee.IRequirementValid>(_RequirementValid);
			
			return iRequirementValidExt;
		}
	}
}
