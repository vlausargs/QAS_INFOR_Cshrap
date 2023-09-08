//PROJECT NAME: CSIEmployee
//CLASS NAME: HrSickFactory.cs

using CSI.MG;

namespace CSI.Employee
{
	public class HrSickFactory
	{
		public IHrSick Create(IApplicationDB appDB)
		{
			var _HrSick = new Employee.HrSick(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHrSickExt = timerfactory.Create<Employee.IHrSick>(_HrSick);
			
			return iHrSickExt;
		}
	}
}
