//PROJECT NAME: CSIProduct
//CLASS NAME: JobtranTransTypeValidFactory.cs

using CSI.MG;

namespace CSI.Production
{
    public class JobtranTransTypeValidFactory
    {
        public IJobtranTransTypeValid Create(IApplicationDB appDB)
        {
            var _JobtranTransTypeValid = new JobtranTransTypeValid(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iJobtranTransTypeValidExt = timerfactory.Create<IJobtranTransTypeValid>(_JobtranTransTypeValid);

            return iJobtranTransTypeValidExt;
        }
    }
}
