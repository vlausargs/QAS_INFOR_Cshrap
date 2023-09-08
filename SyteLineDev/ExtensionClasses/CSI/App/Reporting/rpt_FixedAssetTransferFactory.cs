//PROJECT NAME: Reporting
//CLASS NAME: rpt_FixedAssetTransferFactory.cs

using CSI.MG;
using CSI.Data.RecordSets;

namespace CSI.Reporting
{
	public class rpt_FixedAssetTransferFactory
	{
		public Irpt_FixedAssetTransfer Create(IApplicationDB appDB, IBunchedLoadCollection bunchedLoadCollection)
		{
			var dataTableToCollectionLoadResponse = new DataTableToCollectionLoadResponse();
			var _rpt_FixedAssetTransfer = new Reporting.rpt_FixedAssetTransfer(appDB, bunchedLoadCollection, dataTableToCollectionLoadResponse);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var irpt_FixedAssetTransferExt = timerfactory.Create<Reporting.Irpt_FixedAssetTransfer>(_rpt_FixedAssetTransfer);
			
			return irpt_FixedAssetTransferExt;
		}
	}
}
