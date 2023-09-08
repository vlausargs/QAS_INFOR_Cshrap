//PROJECT NAME: CSIMaterial
//CLASS NAME: TrrcvTrnNumValidFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class TrrcvTrnNumValidFactory
    {
        public ITrrcvTrnNumValid Create(IApplicationDB appDB)
        {
            var _TrrcvTrnNumValid = new Material.TrrcvTrnNumValid(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iTrrcvTrnNumValidExt = timerfactory.Create<Material.ITrrcvTrnNumValid>(_TrrcvTrnNumValid);

            return iTrrcvTrnNumValidExt;
        }
    }
}
