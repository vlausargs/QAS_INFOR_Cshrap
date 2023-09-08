//PROJECT NAME: CSIEmployee
//CLASS NAME: VoidPrtrxChecksToPrintPostFactory.cs

using CSI.MG;

namespace CSI.Employee
{
    public class VoidPrtrxChecksToPrintPostFactory
    {
        public IVoidPrtrxChecksToPrintPost Create(IApplicationDB appDB)
        {
            var _VoidPrtrxChecksToPrintPost = new VoidPrtrxChecksToPrintPost(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iVoidPrtrxChecksToPrintPostExt = timerfactory.Create<IVoidPrtrxChecksToPrintPost>(_VoidPrtrxChecksToPrintPost);

            return iVoidPrtrxChecksToPrintPostExt;
        }
    }
}
