//PROJECT NAME: CSIMaterial
//CLASS NAME: TrrcvTrnLineValidFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class TrrcvTrnLineValidFactory
    {
        public ITrrcvTrnLineValid Create(IApplicationDB appDB)
        {
            var _TrrcvTrnLineValid = new Material.TrrcvTrnLineValid(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iTrrcvTrnLineValidExt = timerfactory.Create<Material.ITrrcvTrnLineValid>(_TrrcvTrnLineValid);

            return iTrrcvTrnLineValidExt;
        }
    }
}
