//PROJECT NAME: CSIRFQ
//CLASS NAME: SSSRFQSendQuoteFactory.cs

using CSI.MG;

namespace CSI.RFQ
{
    public class SSSRFQSendQuoteFactory
    {
        public ISSSRFQSendQuote Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
        {
            var _SSSRFQSendQuote = new RFQ.SSSRFQSendQuote(appDB, bunchedLoadCollection);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSRFQSendQuoteExt = timerfactory.Create<RFQ.ISSSRFQSendQuote>(_SSSRFQSendQuote);

            return iSSSRFQSendQuoteExt;
        }
    }
}
