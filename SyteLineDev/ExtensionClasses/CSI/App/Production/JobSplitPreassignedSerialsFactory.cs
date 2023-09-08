//PROJECT NAME: CSIProduct
//CLASS NAME: JobSplitPreassignedSerialsFactory.cs

using CSI.MG;

namespace CSI.Production
{
    public class JobSplitPreassignedSerialsFactory
    {
        public IJobSplitPreassignedSerials Create(IApplicationDB appDB)
        {
            var _JobSplitPreassignedSerials = new JobSplitPreassignedSerials(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iJobSplitPreassignedSerialsExt = timerfactory.Create<IJobSplitPreassignedSerials>(_JobSplitPreassignedSerials);

            return iJobSplitPreassignedSerialsExt;
        }
    }
}
