//PROJECT NAME: Reporting
//CLASS NAME: Rpt_GSTInvoicedFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_GSTInvoicedFactory
	{
		public IRpt_GSTInvoiced Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_GSTInvoiced = new Reporting.Rpt_GSTInvoiced(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_GSTInvoicedExt = timerfactory.Create<Reporting.IRpt_GSTInvoiced>(_Rpt_GSTInvoiced);
			
			return iRpt_GSTInvoicedExt;
		}
	}
}
