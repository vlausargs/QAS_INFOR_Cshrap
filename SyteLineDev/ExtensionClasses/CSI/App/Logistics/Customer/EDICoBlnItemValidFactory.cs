//PROJECT NAME: CSICustomer
//CLASS NAME: EDICoBlnItemValidFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class EDICoBlnItemValidFactory
    {
        public IEDICoBlnItemValid Create(IApplicationDB appDB)
        {
            var _EDICoBlnItemValid = new Logistics.Customer.EDICoBlnItemValid(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iEDICoBlnItemValidExt = timerfactory.Create<Logistics.Customer.IEDICoBlnItemValid>(_EDICoBlnItemValid);

            return iEDICoBlnItemValidExt;
        }
    }
}
