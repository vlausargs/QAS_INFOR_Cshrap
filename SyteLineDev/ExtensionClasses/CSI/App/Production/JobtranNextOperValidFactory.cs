//PROJECT NAME: CSIProduct
//CLASS NAME: JobtranNextOperValidFactory.cs

using CSI.MG;

namespace CSI.Production
{
    public class JobtranNextOperValidFactory
    {
        public IJobtranNextOperValid Create(IApplicationDB appDB)
        {
            var _JobtranNextOperValid = new JobtranNextOperValid(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iJobtranNextOperValidExt = timerfactory.Create<IJobtranNextOperValid>(_JobtranNextOperValid);

            return iJobtranNextOperValidExt;
        }
    }
}
