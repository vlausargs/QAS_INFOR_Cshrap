//PROJECT NAME: Production
//CLASS NAME: PmfRecallLoadJobMatlTranFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Production.ProcessManufacturing
{
	public class PmfRecallLoadJobMatlTranFactory
	{
		public IPmfRecallLoadJobMatlTran Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _PmfRecallLoadJobMatlTran = new Production.ProcessManufacturing.PmfRecallLoadJobMatlTran(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPmfRecallLoadJobMatlTranExt = timerfactory.Create<Production.ProcessManufacturing.IPmfRecallLoadJobMatlTran>(_PmfRecallLoadJobMatlTran);
			
			return iPmfRecallLoadJobMatlTranExt;
		}
	}
}
