//PROJECT NAME: CSIMaterial
//CLASS NAME: TrnLocValidPostFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class TrnLocValidPostFactory
    {
        public ITrnLocValidPost Create(IApplicationDB appDB)
        {
            var _TrnLocValidPost = new TrnLocValidPost(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iTrnLocValidPostExt = timerfactory.Create<ITrnLocValidPost>(_TrnLocValidPost);

            return iTrnLocValidPostExt;
        }
    }
}
