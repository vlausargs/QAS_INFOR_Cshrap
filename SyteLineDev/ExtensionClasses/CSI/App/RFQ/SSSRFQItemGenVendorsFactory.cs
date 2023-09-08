//PROJECT NAME: CSIRFQ
//CLASS NAME: SSSRFQItemGenVendorsFactory.cs

using CSI.MG;

namespace CSI.RFQ
{
    public class SSSRFQItemGenVendorsFactory
    {
        public ISSSRFQItemGenVendors Create(IApplicationDB appDB)
        {
            var _SSSRFQItemGenVendors = new RFQ.SSSRFQItemGenVendors(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSRFQItemGenVendorsExt = timerfactory.Create<RFQ.ISSSRFQItemGenVendors>(_SSSRFQItemGenVendors);

            return iSSSRFQItemGenVendorsExt;
        }
    }
}
