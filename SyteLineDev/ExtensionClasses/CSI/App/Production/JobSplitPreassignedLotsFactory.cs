//PROJECT NAME: CSIProduct
//CLASS NAME: JobSplitPreassignedLotsFactory.cs

using CSI.MG;

namespace CSI.Production
{
    public class JobSplitPreassignedLotsFactory
    {
        public IJobSplitPreassignedLots Create(IApplicationDB appDB)
        {
            var _JobSplitPreassignedLots = new JobSplitPreassignedLots(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iJobSplitPreassignedLotsExt = timerfactory.Create<IJobSplitPreassignedLots>(_JobSplitPreassignedLots);

            return iJobSplitPreassignedLotsExt;
        }
    }
}
