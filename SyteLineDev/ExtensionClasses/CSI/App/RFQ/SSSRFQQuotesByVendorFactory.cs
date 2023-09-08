//PROJECT NAME: CSIRFQ
//CLASS NAME: SSSRFQQuotesByVendorFactory.cs

using CSI.MG;

namespace CSI.RFQ
{
    public class SSSRFQQuotesByVendorFactory
    {
        public ISSSRFQQuotesByVendor Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _SSSRFQQuotesByVendor = new RFQ.SSSRFQQuotesByVendor(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSRFQQuotesByVendorExt = timerfactory.Create<RFQ.ISSSRFQQuotesByVendor>(_SSSRFQQuotesByVendor);

            return iSSSRFQQuotesByVendorExt;
        }
    }
}
