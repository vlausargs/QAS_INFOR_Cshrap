//PROJECT NAME: CSIProduct
//CLASS NAME: JobtranOperNumValidFactory.cs

using CSI.MG;

namespace CSI.Production
{
    public class JobtranOperNumValidFactory
    {
        public IJobtranOperNumValid Create(IApplicationDB appDB)
        {
            var _JobtranOperNumValid = new JobtranOperNumValid(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iJobtranOperNumValidExt = timerfactory.Create<IJobtranOperNumValid>(_JobtranOperNumValid);

            return iJobtranOperNumValidExt;
        }
    }
}
