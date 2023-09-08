//PROJECT NAME: CSIProduct
//CLASS NAME: JobtranCloseJobValidFactory.cs

using CSI.MG;

namespace CSI.Production
{
    public class JobtranCloseJobValidFactory
    {
        public IJobtranCloseJobValid Create(IApplicationDB appDB)
        {
            var _JobtranCloseJobValid = new JobtranCloseJobValid(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iJobtranCloseJobValidExt = timerfactory.Create<IJobtranCloseJobValid>(_JobtranCloseJobValid);

            return iJobtranCloseJobValidExt;
        }
    }
}
