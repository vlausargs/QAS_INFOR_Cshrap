//PROJECT NAME: Production
//CLASS NAME: PmfRecallLoadPoReceiptFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfRecallLoadPoReceiptFactory
	{
		public IPmfRecallLoadPoReceipt Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _PmfRecallLoadPoReceipt = new Production.ProcessManufacturing.PmfRecallLoadPoReceipt(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfRecallLoadPoReceiptExt = timerfactory.Create<Production.ProcessManufacturing.IPmfRecallLoadPoReceipt>(_PmfRecallLoadPoReceipt);
			
			return iPmfRecallLoadPoReceiptExt;
		}
	}
}
