//PROJECT NAME: CSIMaterial
//CLASS NAME: TrnShipLocChangeFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class TrnShipLocChangeFactory
    {
        public ITrnShipLocChange Create(IApplicationDB appDB)
        {
            var _TrnShipLocChange = new TrnShipLocChange(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iTrnShipLocChangeExt = timerfactory.Create<ITrnShipLocChange>(_TrnShipLocChange);

            return iTrnShipLocChangeExt;
        }
    }
}
