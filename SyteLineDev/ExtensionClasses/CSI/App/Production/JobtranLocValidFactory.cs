//PROJECT NAME: CSIProduct
//CLASS NAME: JobtranLocValidFactory.cs

using CSI.MG;

namespace CSI.Production
{
    public class JobtranLocValidFactory
    {
        public IJobtranLocValid Create(IApplicationDB appDB)
        {
            var _JobtranLocValid = new JobtranLocValid(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iJobtranLocValidExt = timerfactory.Create<IJobtranLocValid>(_JobtranLocValid);

            return iJobtranLocValidExt;
        }
    }
}
