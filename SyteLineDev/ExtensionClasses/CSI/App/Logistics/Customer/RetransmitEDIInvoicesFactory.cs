//PROJECT NAME: CSICustomer
//CLASS NAME: RetransmitEDIInvoicesFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class RetransmitEDIInvoicesFactory
    {
        public IRetransmitEDIInvoices Create(IApplicationDB appDB)
        {
            var _RetransmitEDIInvoices = new Logistics.Customer.RetransmitEDIInvoices(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iRetransmitEDIInvoicesExt = timerfactory.Create<Logistics.Customer.IRetransmitEDIInvoices>(_RetransmitEDIInvoices);

            return iRetransmitEDIInvoicesExt;
        }
    }
}
