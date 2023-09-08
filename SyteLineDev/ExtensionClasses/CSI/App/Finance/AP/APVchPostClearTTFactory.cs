//PROJECT NAME: CSIVendor
//CLASS NAME: APVchPostClearTTFactory.cs

using CSI.MG;

namespace CSI.Finance.AP
{
    public class APVchPostClearTTFactory
    {
        public IAPVchPostClearTT Create(IApplicationDB appDB)
        {
            var _APVchPostClearTT = new APVchPostClearTT(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iAPVchPostClearTTExt = timerfactory.Create<IAPVchPostClearTT>(_APVchPostClearTT);

            return iAPVchPostClearTTExt;
        }
    }
}
