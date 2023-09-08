//PROJECT NAME: Employee
//CLASS NAME: HrVerifyDelPosDetFactory.cs

using CSI.MG;

namespace CSI.Employee
{
	public class HrVerifyDelPosDetFactory
	{
		public IHrVerifyDelPosDet Create(IApplicationDB appDB)
		{
			var _HrVerifyDelPosDet = new Employee.HrVerifyDelPosDet(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHrVerifyDelPosDetExt = timerfactory.Create<Employee.IHrVerifyDelPosDet>(_HrVerifyDelPosDet);
			
			return iHrVerifyDelPosDetExt;
		}
	}
}
