//PROJECT NAME: CSICustomer
//CLASS NAME: SSSRMXDispValidRmaFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class SSSRMXDispValidRmaFactory
    {
        public ISSSRMXDispValidRma Create(IApplicationDB appDB)
        {
            var _SSSRMXDispValidRma = new Logistics.Customer.SSSRMXDispValidRma(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSRMXDispValidRmaExt = timerfactory.Create<Logistics.Customer.ISSSRMXDispValidRma>(_SSSRMXDispValidRma);

            return iSSSRMXDispValidRmaExt;
        }
    }
}
