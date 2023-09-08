//PROJECT NAME: BusInterface
//CLASS NAME: LoadESBEmployeeTimesheetFactory.cs

using CSI.MG;

namespace CSI.BusInterface
{
	public class LoadESBEmployeeTimesheetFactory
	{
		public ILoadESBEmployeeTimesheet Create(IApplicationDB appDB)
		{
			var _LoadESBEmployeeTimesheet = new BusInterface.LoadESBEmployeeTimesheet(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBEmployeeTimesheetExt = timerfactory.Create<BusInterface.ILoadESBEmployeeTimesheet>(_LoadESBEmployeeTimesheet);
			
			return iLoadESBEmployeeTimesheetExt;
		}
	}
}
