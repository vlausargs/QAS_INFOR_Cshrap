//PROJECT NAME: CSIEmployee
//CLASS NAME: DepDelFactory.cs

using CSI.MG;

namespace CSI.Employee
{
	public class DepDelFactory
	{
		public IDepDel Create(IApplicationDB appDB)
		{
			var _DepDel = new Employee.DepDel(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDepDelExt = timerfactory.Create<Employee.IDepDel>(_DepDel);
			
			return iDepDelExt;
		}
	}
}
