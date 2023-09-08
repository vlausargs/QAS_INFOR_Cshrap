//PROJECT NAME: CSICustomer
//CLASS NAME: RetransmitEdiAckFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class RetransmitEdiAckFactory
    {
        public IRetransmitEdiAck Create(IApplicationDB appDB)
        {
            var _RetransmitEdiAck = new Logistics.Customer.RetransmitEdiAck(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iRetransmitEdiAckExt = timerfactory.Create<Logistics.Customer.IRetransmitEdiAck>(_RetransmitEdiAck);

            return iRetransmitEdiAckExt;
        }
    }
}
