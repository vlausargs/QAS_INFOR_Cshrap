//PROJECT NAME: CSICustomer
//CLASS NAME: SSSOPMShipCheckFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class SSSOPMShipCheckFactory
    {
        public ISSSOPMShipCheck Create(IApplicationDB appDB)
        {
            var _SSSOPMShipCheck = new Logistics.Customer.SSSOPMShipCheck(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSOPMShipCheckExt = timerfactory.Create<Logistics.Customer.ISSSOPMShipCheck>(_SSSOPMShipCheck);

            return iSSSOPMShipCheckExt;
        }
    }
}
