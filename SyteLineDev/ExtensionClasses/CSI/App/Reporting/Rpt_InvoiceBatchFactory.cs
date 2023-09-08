//PROJECT NAME: Reporting
//CLASS NAME: Rpt_InvoiceBatchFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_InvoiceBatchFactory
	{
		public IRpt_InvoiceBatch Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_InvoiceBatch = new Reporting.Rpt_InvoiceBatch(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_InvoiceBatchExt = timerfactory.Create<Reporting.IRpt_InvoiceBatch>(_Rpt_InvoiceBatch);
			
			return iRpt_InvoiceBatchExt;
		}
	}
}
