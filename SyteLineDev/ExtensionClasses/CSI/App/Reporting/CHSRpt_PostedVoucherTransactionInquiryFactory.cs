//PROJECT NAME: CSIReport
//CLASS NAME: CHSRpt_PostedVoucherTransactionInquiryFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class CHSRpt_PostedVoucherTransactionInquiryFactory
	{
		public ICHSRpt_PostedVoucherTransactionInquiry Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CHSRpt_PostedVoucherTransactionInquiry = new Reporting.CHSRpt_PostedVoucherTransactionInquiry(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCHSRpt_PostedVoucherTransactionInquiryExt = timerfactory.Create<Reporting.ICHSRpt_PostedVoucherTransactionInquiry>(_CHSRpt_PostedVoucherTransactionInquiry);
			
			return iCHSRpt_PostedVoucherTransactionInquiryExt;
		}
	}
}
