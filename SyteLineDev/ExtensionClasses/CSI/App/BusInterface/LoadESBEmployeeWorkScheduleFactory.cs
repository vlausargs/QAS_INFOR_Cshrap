//PROJECT NAME: BusInterface
//CLASS NAME: LoadESBEmployeeWorkScheduleFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.BusInterface
{
	public class LoadESBEmployeeWorkScheduleFactory
	{
		public ILoadESBEmployeeWorkSchedule Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _LoadESBEmployeeWorkSchedule = new BusInterface.LoadESBEmployeeWorkSchedule(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLoadESBEmployeeWorkScheduleExt = timerfactory.Create<BusInterface.ILoadESBEmployeeWorkSchedule>(_LoadESBEmployeeWorkSchedule);
			
			return iLoadESBEmployeeWorkScheduleExt;
		}
	}
}
