//PROJECT NAME: Employee
//CLASS NAME: PrtrxClearSnapshotsFactory.cs

using CSI.MG;

namespace CSI.Employee
{
	public class PrtrxClearSnapshotsFactory
	{
		public IPrtrxClearSnapshots Create(IApplicationDB appDB)
		{
			var _PrtrxClearSnapshots = new Employee.PrtrxClearSnapshots(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPrtrxClearSnapshotsExt = timerfactory.Create<Employee.IPrtrxClearSnapshots>(_PrtrxClearSnapshots);
			
			return iPrtrxClearSnapshotsExt;
		}
	}
}
