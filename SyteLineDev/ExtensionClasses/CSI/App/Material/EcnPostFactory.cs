//PROJECT NAME: CSIMaterial
//CLASS NAME: EcnPostFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class EcnPostFactory
    {
        public IEcnPost Create(IApplicationDB appDB)
        {
            var _EcnPost = new EcnPost(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iEcnPostExt = timerfactory.Create<IEcnPost>(_EcnPost);

            return iEcnPostExt;
        }
    }
}
