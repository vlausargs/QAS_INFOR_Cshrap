//PROJECT NAME: Material
//CLASS NAME: ShipLocDefaultFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
    public class ShipLocDefaultFactory
    {
        public IShipLocDefault Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
        {
            var appDB = cSIExtensionClassBase.AppDB;
            var _ShipLocDefault = new Material.ShipLocDefault(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iShipLocDefaultExt = timerfactory.Create<Material.IShipLocDefault>(_ShipLocDefault);

            return iShipLocDefaultExt;
        }
    }
}
