//PROJECT NAME: CSICustomer
//CLASS NAME: SSSOPMShipOneFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class SSSOPMShipOneFactory
    {
        public ISSSOPMShipOne Create(IApplicationDB appDB)
        {
            var _SSSOPMShipOne = new Logistics.Customer.SSSOPMShipOne(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSOPMShipOneExt = timerfactory.Create<Logistics.Customer.ISSSOPMShipOne>(_SSSOPMShipOne);

            return iSSSOPMShipOneExt;
        }
    }
}
