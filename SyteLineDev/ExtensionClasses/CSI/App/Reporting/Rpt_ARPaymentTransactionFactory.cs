//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ARPaymentTransactionFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ARPaymentTransactionFactory
	{
		public IRpt_ARPaymentTransaction Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ARPaymentTransaction = new Reporting.Rpt_ARPaymentTransaction(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ARPaymentTransactionExt = timerfactory.Create<Reporting.IRpt_ARPaymentTransaction>(_Rpt_ARPaymentTransaction);
			
			return iRpt_ARPaymentTransactionExt;
		}
	}
}
