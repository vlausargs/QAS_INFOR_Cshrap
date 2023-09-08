//PROJECT NAME: CSICustomer
//CLASS NAME: SyncOutlookContactFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class SyncOutlookContactFactory
    {
        public ISyncOutlookContact Create(IApplicationDB appDB)
        {
            var _SyncOutlookContact = new Customer.SyncOutlookContact(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSyncOutlookContactExt = timerfactory.Create<Customer.ISyncOutlookContact>(_SyncOutlookContact);

            return iSyncOutlookContactExt;
        }
    }
}
