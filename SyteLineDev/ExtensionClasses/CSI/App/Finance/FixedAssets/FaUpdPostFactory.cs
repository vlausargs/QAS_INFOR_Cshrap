//PROJECT NAME: CSIFinance
//CLASS NAME: FaUpdPostFactory.cs

using CSI.MG;

namespace CSI.Finance.FixedAssets
{
    public class FaUpdPostFactory
    {
        public IFaUpdPost Create(IApplicationDB appDB)
        {
            var _FaUpdPost = new FaUpdPost(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSLFaDeprsExt = timerfactory.Create<IFaUpdPost>(_FaUpdPost);

            return iSLFaDeprsExt;
        }
    }
}
