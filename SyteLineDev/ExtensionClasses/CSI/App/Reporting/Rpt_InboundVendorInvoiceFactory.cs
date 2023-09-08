//PROJECT NAME: Reporting
//CLASS NAME: Rpt_InboundVendorInvoiceFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_InboundVendorInvoiceFactory
	{
		public IRpt_InboundVendorInvoice Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_InboundVendorInvoice = new Reporting.Rpt_InboundVendorInvoice(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_InboundVendorInvoiceExt = timerfactory.Create<Reporting.IRpt_InboundVendorInvoice>(_Rpt_InboundVendorInvoice);
			
			return iRpt_InboundVendorInvoiceExt;
		}
	}
}
