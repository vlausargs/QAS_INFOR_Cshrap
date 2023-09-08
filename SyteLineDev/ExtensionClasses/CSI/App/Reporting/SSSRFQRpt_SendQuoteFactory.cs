//PROJECT NAME: Reporting
//CLASS NAME: SSSRFQRpt_SendQuoteFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class SSSRFQRpt_SendQuoteFactory
	{
		public ISSSRFQRpt_SendQuote Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSRFQRpt_SendQuote = new Reporting.SSSRFQRpt_SendQuote(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSRFQRpt_SendQuoteExt = timerfactory.Create<Reporting.ISSSRFQRpt_SendQuote>(_SSSRFQRpt_SendQuote);
			
			return iSSSRFQRpt_SendQuoteExt;
		}
	}
}
