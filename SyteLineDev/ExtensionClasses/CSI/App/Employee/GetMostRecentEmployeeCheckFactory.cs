//PROJECT NAME: CSIEmployee
//CLASS NAME: GetMostRecentEmployeeCheckFactory.cs

using CSI.MG;

namespace CSI.Employee
{
	public class GetMostRecentEmployeeCheckFactory
	{
		public IGetMostRecentEmployeeCheck Create(IApplicationDB appDB)
		{
			var _GetMostRecentEmployeeCheck = new Employee.GetMostRecentEmployeeCheck(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetMostRecentEmployeeCheckExt = timerfactory.Create<Employee.IGetMostRecentEmployeeCheck>(_GetMostRecentEmployeeCheck);
			
			return iGetMostRecentEmployeeCheckExt;
		}
	}
}
