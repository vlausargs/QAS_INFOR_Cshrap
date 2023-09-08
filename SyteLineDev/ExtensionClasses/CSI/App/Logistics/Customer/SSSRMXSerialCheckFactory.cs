//PROJECT NAME: CSICustomer
//CLASS NAME: SSSRMXSerialCheckFactory.cs

using CSI.MG;

namespace CSI.Logistics.Customer
{
    public class SSSRMXSerialCheckFactory
    {
        public ISSSRMXSerialCheck Create(IApplicationDB appDB)
        {
            var _SSSRMXSerialCheck = new Logistics.Customer.SSSRMXSerialCheck(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSRMXSerialCheckExt = timerfactory.Create<Logistics.Customer.ISSSRMXSerialCheck>(_SSSRMXSerialCheck);

            return iSSSRMXSerialCheckExt;
        }
    }
}
