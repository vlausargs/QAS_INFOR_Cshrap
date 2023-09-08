//PROJECT NAME: CSIProduct
//CLASS NAME: JobSplitValidFactory.cs

using CSI.MG;

namespace CSI.Production
{
    public class JobSplitValidFactory
    {
        public IJobSplitValid Create(IApplicationDB appDB)
        {
            var _JobSplitValid = new JobSplitValid(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iJobSplitValidExt = timerfactory.Create<IJobSplitValid>(_JobSplitValid);

            return iJobSplitValidExt;
        }
    }
}
