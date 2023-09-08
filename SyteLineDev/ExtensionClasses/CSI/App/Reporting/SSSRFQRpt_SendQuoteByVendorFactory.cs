//PROJECT NAME: Reporting
//CLASS NAME: SSSRFQRpt_SendQuoteByVendorFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class SSSRFQRpt_SendQuoteByVendorFactory
	{
		public ISSSRFQRpt_SendQuoteByVendor Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _SSSRFQRpt_SendQuoteByVendor = new Reporting.SSSRFQRpt_SendQuoteByVendor(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSRFQRpt_SendQuoteByVendorExt = timerfactory.Create<Reporting.ISSSRFQRpt_SendQuoteByVendor>(_SSSRFQRpt_SendQuoteByVendor);
			
			return iSSSRFQRpt_SendQuoteByVendorExt;
		}
	}
}
