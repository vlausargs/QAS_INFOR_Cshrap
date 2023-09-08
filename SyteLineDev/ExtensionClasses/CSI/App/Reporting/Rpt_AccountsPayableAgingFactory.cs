//PROJECT NAME: Reporting
//CLASS NAME: Rpt_AccountsPayableAgingFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_AccountsPayableAgingFactory
	{
		public IRpt_AccountsPayableAging Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_AccountsPayableAging = new Reporting.Rpt_AccountsPayableAging(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_AccountsPayableAgingExt = timerfactory.Create<Reporting.IRpt_AccountsPayableAging>(_Rpt_AccountsPayableAging);
			
			return iRpt_AccountsPayableAgingExt;
		}
	}
}
