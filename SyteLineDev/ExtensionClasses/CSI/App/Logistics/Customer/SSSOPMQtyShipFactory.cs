//PROJECT NAME: CSICustomer
//CLASS NAME: SSSOPMQtyShipFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class SSSOPMQtyShipFactory
    {
        public ISSSOPMQtyShip Create(IApplicationDB appDB)
        {
            var _SSSOPMQtyShip = new Logistics.Customer.SSSOPMQtyShip(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSOPMQtyShipExt = timerfactory.Create<Logistics.Customer.ISSSOPMQtyShip>(_SSSOPMQtyShip);

            return iSSSOPMQtyShipExt;
        }
    }
}
