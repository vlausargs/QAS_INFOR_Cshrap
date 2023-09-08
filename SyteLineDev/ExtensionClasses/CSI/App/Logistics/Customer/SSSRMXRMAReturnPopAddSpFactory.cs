//PROJECT NAME: CSICustomer
//CLASS NAME: SSSRMXRMAReturnPopAddFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class SSSRMXRMAReturnPopAddFactory
    {
        public ISSSRMXRMAReturnPopAdd Create(IApplicationDB appDB)
        {
            var _SSSRMXRMAReturnPopAdd = new Logistics.Customer.SSSRMXRMAReturnPopAdd(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSRMXRMAReturnPopAddExt = timerfactory.Create<Logistics.Customer.ISSSRMXRMAReturnPopAdd>(_SSSRMXRMAReturnPopAdd);

            return iSSSRMXRMAReturnPopAddExt;
        }
    }
}
