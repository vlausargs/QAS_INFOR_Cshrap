//PROJECT NAME: CSIAdmin
//CLASS NAME: JobCalendarFactory.cs

using CSI.MG;

namespace CSI.Admin
{
    public class JobCalendarFactory
    {
        public IJobCalendar Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _JobCalendar = new JobCalendar(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iJobCalendarExt = timerfactory.Create<IJobCalendar>(_JobCalendar);

            return iJobCalendarExt;
        }
    }
}
