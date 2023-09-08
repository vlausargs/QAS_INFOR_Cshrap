//PROJECT NAME: CSIMaterial
//CLASS NAME: TrrcvFromLotValidFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class TrrcvFromLotValidFactory
    {
        public ITrrcvFromLotValid Create(IApplicationDB appDB)
        {
            var _TrrcvFromLotValid = new TrrcvFromLotValid(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iTrrcvFromLotValidExt = timerfactory.Create<ITrrcvFromLotValid>(_TrrcvFromLotValid);

            return iTrrcvFromLotValidExt;
        }
    }
}
