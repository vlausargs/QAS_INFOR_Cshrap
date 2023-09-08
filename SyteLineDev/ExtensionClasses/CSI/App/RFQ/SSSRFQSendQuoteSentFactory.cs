//PROJECT NAME: CSIRFQ
//CLASS NAME: SSSRFQSendQuoteSentFactory.cs

using CSI.MG;

namespace CSI.RFQ
{
    public class SSSRFQSendQuoteSentFactory
    {
        public ISSSRFQSendQuoteSent Create(IApplicationDB appDB)
        {
            var _SSSRFQSendQuoteSent = new RFQ.SSSRFQSendQuoteSent(appDB);

            var timerfactory = new CSI.Data.Metric.TimerFactory();
            var iSSSRFQSendQuoteSentExt = timerfactory.Create<RFQ.ISSSRFQSendQuoteSent>(_SSSRFQSendQuoteSent);

            return iSSSRFQSendQuoteSentExt;
        }
    }
}
