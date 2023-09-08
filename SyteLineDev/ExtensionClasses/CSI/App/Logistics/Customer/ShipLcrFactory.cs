//PROJECT NAME: Logistics
//CLASS NAME: ShipLcrFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
    public class ShipLcrFactory
    {
        public IShipLcr Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
        {
            var appDB = cSIExtensionClassBase.AppDB;

            var _ShipLcr = new Logistics.Customer.ShipLcr(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iShipLcrExt = timerfactory.Create<Logistics.Customer.IShipLcr>(_ShipLcr);

            return iShipLcrExt;
        }
    }
}
