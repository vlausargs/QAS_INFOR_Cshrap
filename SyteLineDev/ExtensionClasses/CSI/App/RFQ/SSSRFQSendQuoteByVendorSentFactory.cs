//PROJECT NAME: RFQ
//CLASS NAME: SSSRFQSendQuoteByVendorSentFactory.cs

using CSI.MG;

namespace CSI.RFQ
{
	public class SSSRFQSendQuoteByVendorSentFactory
	{
		public ISSSRFQSendQuoteByVendorSent Create(IApplicationDB appDB)
		{
			var _SSSRFQSendQuoteByVendorSent = new RFQ.SSSRFQSendQuoteByVendorSent(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSRFQSendQuoteByVendorSentExt = timerfactory.Create<RFQ.ISSSRFQSendQuoteByVendorSent>(_SSSRFQSendQuoteByVendorSent);
			
			return iSSSRFQSendQuoteByVendorSentExt;
		}
	}
}
