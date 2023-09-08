//PROJECT NAME: CSICustomer
//CLASS NAME: EdiCoBlnRelValidQtyOrderedFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class EdiCoBlnRelValidQtyOrderedFactory
    {
        public IEdiCoBlnRelValidQtyOrdered Create(IApplicationDB appDB)
        {
            var _EdiCoBlnRelValidQtyOrdered = new Logistics.Customer.EdiCoBlnRelValidQtyOrdered(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iEdiCoBlnRelValidQtyOrderedExt = timerfactory.Create<Logistics.Customer.IEdiCoBlnRelValidQtyOrdered>(_EdiCoBlnRelValidQtyOrdered);

            return iEdiCoBlnRelValidQtyOrderedExt;
        }
    }
}
