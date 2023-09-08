//PROJECT NAME: Employee
//CLASS NAME: HrNextPosFactory.cs

using CSI.MG;

namespace CSI.Employee
{
	public class HrNextPosFactory
	{
		public IHrNextPos Create(IApplicationDB appDB)
		{
			var _HrNextPos = new Employee.HrNextPos(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHrNextPosExt = timerfactory.Create<Employee.IHrNextPos>(_HrNextPos);
			
			return iHrNextPosExt;
		}
	}
}
