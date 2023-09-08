//PROJECT NAME: CSIReport
//CLASS NAME: CHSRpt_PostedVoucherInquiryFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class CHSRpt_PostedVoucherInquiryFactory
	{
		public ICHSRpt_PostedVoucherInquiry Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _CHSRpt_PostedVoucherInquiry = new Reporting.CHSRpt_PostedVoucherInquiry(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCHSRpt_PostedVoucherInquiryExt = timerfactory.Create<Reporting.ICHSRpt_PostedVoucherInquiry>(_CHSRpt_PostedVoucherInquiry);
			
			return iCHSRpt_PostedVoucherInquiryExt;
		}
	}
}
