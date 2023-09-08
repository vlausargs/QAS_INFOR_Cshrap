//PROJECT NAME: CSIMaterial
//CLASS NAME: TrnShipTrnNumValidFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class TrnShipTrnNumValidFactory
    {
        public ITrnShipTrnNumValid Create(IApplicationDB appDB)
        {
            var _TrnShipTrnNumValid = new TrnShipTrnNumValid(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iTrnShipTrnNumValidExt = timerfactory.Create<ITrnShipTrnNumValid>(_TrnShipTrnNumValid);

            return iTrnShipTrnNumValidExt;
        }
    }
}
