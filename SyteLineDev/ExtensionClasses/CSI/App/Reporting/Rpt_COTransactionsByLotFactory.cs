//PROJECT NAME: Reporting
//CLASS NAME: Rpt_COTransactionsByLotFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class Rpt_COTransactionsByLotFactory
	{
		public IRpt_COTransactionsByLot Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _Rpt_COTransactionsByLot = new Reporting.Rpt_COTransactionsByLot(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRpt_COTransactionsByLotExt = timerfactory.Create<Reporting.IRpt_COTransactionsByLot>(_Rpt_COTransactionsByLot);
			
			return iRpt_COTransactionsByLotExt;
		}
	}
}
