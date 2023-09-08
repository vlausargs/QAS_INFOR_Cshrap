//PROJECT NAME: CSIProduct
//CLASS NAME: JobParmUpdateBasisFactory.cs

using CSI.MG;

namespace CSI.Production
{
    public class JobParmUpdateBasisFactory
    {
        public IJobParmUpdateBasis Create(IApplicationDB appDB)
        {
            var _JobParmUpdateBasis = new JobParmUpdateBasis(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iJobParmUpdateBasisExt = timerfactory.Create<IJobParmUpdateBasis>(_JobParmUpdateBasis);

            return iJobParmUpdateBasisExt;
        }
    }
}
