//PROJECT NAME: CSIProduct
//CLASS NAME: PsitemPreDeleteFactory.cs

using CSI.MG;

namespace CSI.Production
{
    public class PsitemPreDeleteFactory
    {
        public IPsitemPreDelete Create(IApplicationDB appDB)
        {
            var _PsitemPreDelete = new PsitemPreDelete(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iPsitemPreDeleteExt = timerfactory.Create<IPsitemPreDelete>(_PsitemPreDelete);

            return iPsitemPreDeleteExt;
        }
    }
}
