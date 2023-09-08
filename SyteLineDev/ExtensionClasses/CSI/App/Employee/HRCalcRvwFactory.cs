//PROJECT NAME: CSIEmployee
//CLASS NAME: HRCalcRvwFactory.cs

using CSI.MG;

namespace CSI.Employee
{
	public class HRCalcRvwFactory
	{
		public IHRCalcRvw Create(IApplicationDB appDB)
		{
			var _HRCalcRvw = new Employee.HRCalcRvw(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iHRCalcRvwExt = timerfactory.Create<Employee.IHRCalcRvw>(_HRCalcRvw);
			
			return iHRCalcRvwExt;
		}
	}
}
