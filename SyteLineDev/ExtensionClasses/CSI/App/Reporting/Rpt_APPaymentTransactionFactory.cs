//PROJECT NAME: Reporting
//CLASS NAME: Rpt_APPaymentTransactionFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_APPaymentTransactionFactory
	{
		public IRpt_APPaymentTransaction Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_APPaymentTransaction = new Reporting.Rpt_APPaymentTransaction(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_APPaymentTransactionExt = timerfactory.Create<Reporting.IRpt_APPaymentTransaction>(_Rpt_APPaymentTransaction);
			
			return iRpt_APPaymentTransactionExt;
		}
	}
}
