//PROJECT NAME: Employee
//CLASS NAME: ValidateProcessStatusFactory.cs

using CSI.MG;

namespace CSI.Employee
{
	public class ValidateProcessStatusFactory
	{
		public IValidateProcessStatus Create(IApplicationDB appDB)
		{
			var _ValidateProcessStatus = new Employee.ValidateProcessStatus(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateProcessStatusExt = timerfactory.Create<Employee.IValidateProcessStatus>(_ValidateProcessStatus);
			
			return iValidateProcessStatusExt;
		}
	}
}
