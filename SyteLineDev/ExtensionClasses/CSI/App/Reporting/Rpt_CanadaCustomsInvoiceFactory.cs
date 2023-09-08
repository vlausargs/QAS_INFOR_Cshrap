//PROJECT NAME: Reporting
//CLASS NAME: Rpt_CanadaCustomsInvoiceFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_CanadaCustomsInvoiceFactory
	{
		public IRpt_CanadaCustomsInvoice Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_CanadaCustomsInvoice = new Reporting.Rpt_CanadaCustomsInvoice(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_CanadaCustomsInvoiceExt = timerfactory.Create<Reporting.IRpt_CanadaCustomsInvoice>(_Rpt_CanadaCustomsInvoice);
			
			return iRpt_CanadaCustomsInvoiceExt;
		}
	}
}
