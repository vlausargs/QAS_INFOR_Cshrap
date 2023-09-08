//PROJECT NAME: CSIProduct
//CLASS NAME: JobSplitValidationFactory.cs

using CSI.MG;

namespace CSI.Production
{
    public class JobSplitValidationFactory
    {
        public IJobSplitValidation Create(IApplicationDB appDB)
        {
            var _JobSplitValidation = new JobSplitValidation(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iJobSplitValidationExt = timerfactory.Create<IJobSplitValidation>(_JobSplitValidation);

            return iJobSplitValidationExt;
        }
    }
}
