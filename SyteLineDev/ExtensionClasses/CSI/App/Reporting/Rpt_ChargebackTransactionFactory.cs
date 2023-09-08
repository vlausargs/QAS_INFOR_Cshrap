//PROJECT NAME: Reporting
//CLASS NAME: Rpt_ChargebackTransactionFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_ChargebackTransactionFactory
	{
		public IRpt_ChargebackTransaction Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_ChargebackTransaction = new Reporting.Rpt_ChargebackTransaction(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_ChargebackTransactionExt = timerfactory.Create<Reporting.IRpt_ChargebackTransaction>(_Rpt_ChargebackTransaction);
			
			return iRpt_ChargebackTransactionExt;
		}
	}
}
