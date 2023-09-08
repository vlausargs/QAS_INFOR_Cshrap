//PROJECT NAME: CSIMaterial
//CLASS NAME: TlocChkPostFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class TlocChkPostFactory
    {
        public ITlocChkPost Create(IApplicationDB appDB)
        {
            var _TlocChkPost = new TlocChkPost(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iTlocChkPostExt = timerfactory.Create<ITlocChkPost>(_TlocChkPost);

            return iTlocChkPostExt;
        }
    }
}
