//PROJECT NAME: CSIRFQ
//CLASS NAME: SSSRFQSendQuoteByVendorSent2Factory.cs

using CSI.MG;

namespace CSI.RFQ
{
    public class SSSRFQSendQuoteByVendorSent2Factory
    {
        public ISSSRFQSendQuoteByVendorSent2 Create(IApplicationDB appDB)
        {
            var _SSSRFQSendQuoteByVendorSent2 = new RFQ.SSSRFQSendQuoteByVendorSent2(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSRFQSendQuoteByVendorSent2Ext = timerfactory.Create<RFQ.ISSSRFQSendQuoteByVendorSent2>(_SSSRFQSendQuoteByVendorSent2);

            return iSSSRFQSendQuoteByVendorSent2Ext;
        }
    }
}
