//PROJECT NAME: Employee
//CLASS NAME: HrNextPosDetFactory.cs

using CSI.MG;

namespace CSI.Employee
{
	public class HrNextPosDetFactory
	{
		public IHrNextPosDet Create(IApplicationDB appDB)
		{
			var _HrNextPosDet = new Employee.HrNextPosDet(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHrNextPosDetExt = timerfactory.Create<Employee.IHrNextPosDet>(_HrNextPosDet);
			
			return iHrNextPosDetExt;
		}
	}
}
