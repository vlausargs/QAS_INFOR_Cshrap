//PROJECT NAME: CSIMaterial
//CLASS NAME: TrnShipLocValidFactory.cs

using CSI.MG;

namespace CSI.Material
{
    public class TrnShipLocValidFactory
    {
        public ITrnShipLocValid Create(IApplicationDB appDB)
        {
            var _TrnShipLocValid = new Material.TrnShipLocValid(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iTrnShipLocValidExt = timerfactory.Create<Material.ITrnShipLocValid>(_TrnShipLocValid);

            return iTrnShipLocValidExt;
        }
    }
}
