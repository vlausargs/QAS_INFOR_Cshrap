//PROJECT NAME: RFQ
//CLASS NAME: SSSRFQCheckSentQuotesFactory.cs

using CSI.MG;

namespace CSI.RFQ
{
	public class SSSRFQCheckSentQuotesFactory
	{
		public ISSSRFQCheckSentQuotes Create(IApplicationDB appDB)
		{
			var _SSSRFQCheckSentQuotes = new RFQ.SSSRFQCheckSentQuotes(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSRFQCheckSentQuotesExt = timerfactory.Create<RFQ.ISSSRFQCheckSentQuotes>(_SSSRFQCheckSentQuotes);
			
			return iSSSRFQCheckSentQuotesExt;
		}
	}
}
