//PROJECT NAME: Employee
//CLASS NAME: HrVerifyDelPosFactory.cs

using CSI.MG;

namespace CSI.Employee
{
	public class HrVerifyDelPosFactory
	{
		public IHrVerifyDelPos Create(IApplicationDB appDB)
		{
			var _HrVerifyDelPos = new Employee.HrVerifyDelPos(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHrVerifyDelPosExt = timerfactory.Create<Employee.IHrVerifyDelPos>(_HrVerifyDelPos);
			
			return iHrVerifyDelPosExt;
		}
	}
}
