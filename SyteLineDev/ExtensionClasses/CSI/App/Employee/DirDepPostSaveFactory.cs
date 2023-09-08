//PROJECT NAME: Employee
//CLASS NAME: DirDepPostSaveFactory.cs

using CSI.MG;

namespace CSI.Employee
{
	public class DirDepPostSaveFactory
	{
		public IDirDepPostSave Create(IApplicationDB appDB)
		{
			var _DirDepPostSave = new Employee.DirDepPostSave(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iDirDepPostSaveExt = timerfactory.Create<Employee.IDirDepPostSave>(_DirDepPostSave);
			
			return iDirDepPostSaveExt;
		}
	}
}
