//PROJECT NAME: Employee
//CLASS NAME: SaveTaskforFutureProcessesFactory.cs

using CSI.MG;

namespace CSI.Employee
{
	public class SaveTaskforFutureProcessesFactory
	{
		public ISaveTaskforFutureProcesses Create(IApplicationDB appDB)
		{
			var _SaveTaskforFutureProcesses = new Employee.SaveTaskforFutureProcesses(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSaveTaskforFutureProcessesExt = timerfactory.Create<Employee.ISaveTaskforFutureProcesses>(_SaveTaskforFutureProcesses);
			
			return iSaveTaskforFutureProcessesExt;
		}
	}
}
