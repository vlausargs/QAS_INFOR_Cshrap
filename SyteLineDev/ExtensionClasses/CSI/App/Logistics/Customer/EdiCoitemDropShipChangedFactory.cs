//PROJECT NAME: CSICustomer
//CLASS NAME: EdiCoitemDropShipChangedFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class EdiCoitemDropShipChangedFactory
    {
        public IEdiCoitemDropShipChanged Create(IApplicationDB appDB)
        {
            var _EdiCoitemDropShipChanged = new Logistics.Customer.EdiCoitemDropShipChanged(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iEdiCoitemDropShipChangedExt = timerfactory.Create<Logistics.Customer.IEdiCoitemDropShipChanged>(_EdiCoitemDropShipChanged);

            return iEdiCoitemDropShipChangedExt;
        }
    }
}
