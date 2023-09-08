//PROJECT NAME: CSICustomer
//CLASS NAME: RetransmitEdiASNFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class RetransmitEdiASNFactory
    {
        public IRetransmitEdiASN Create(IApplicationDB appDB)
        {
            var _RetransmitEdiASN = new Logistics.Customer.RetransmitEdiASN(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iRetransmitEdiASNExt = timerfactory.Create<Logistics.Customer.IRetransmitEdiASN>(_RetransmitEdiASN);

            return iRetransmitEdiASNExt;
        }
    }
}
