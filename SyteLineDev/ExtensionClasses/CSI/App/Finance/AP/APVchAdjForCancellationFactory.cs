//PROJECT NAME: CSIVendor
//CLASS NAME: APVchAdjForCancellationFactory.cs

using CSI.MG;

namespace CSI.Finance.AP
{
    public class APVchAdjForCancellationFactory
    {
        public IAPVchAdjForCancellation Create(IApplicationDB appDB)
        {
            var _APVchAdjForCancellation = new APVchAdjForCancellation(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iAPVchAdjForCancellationExt = timerfactory.Create<IAPVchAdjForCancellation>(_APVchAdjForCancellation);

            return iAPVchAdjForCancellationExt;
        }
    }
}
