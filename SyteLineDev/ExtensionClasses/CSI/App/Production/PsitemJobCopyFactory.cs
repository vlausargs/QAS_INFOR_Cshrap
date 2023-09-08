//PROJECT NAME: CSIProduct
//CLASS NAME: PsitemJobCopyFactory.cs

using CSI.MG;

namespace CSI.Production
{
    public class PsitemJobCopyFactory
    {
        public IPsitemJobCopy Create(IApplicationDB appDB)
        {
            var _PsitemJobCopy = new PsitemJobCopy(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iPsitemJobCopyExt = timerfactory.Create<IPsitemJobCopy>(_PsitemJobCopy);

            return iPsitemJobCopyExt;
        }
    }
}
