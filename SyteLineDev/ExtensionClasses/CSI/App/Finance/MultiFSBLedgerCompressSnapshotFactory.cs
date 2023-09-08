//PROJECT NAME: CSIFinance
//CLASS NAME: MultiFSBLedgerCompressSnapshotFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class MultiFSBLedgerCompressSnapshotFactory
	{
		public IMultiFSBLedgerCompressSnapshot Create(IApplicationDB appDB)
		{
			var _MultiFSBLedgerCompressSnapshot = new Finance.MultiFSBLedgerCompressSnapshot(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMultiFSBLedgerCompressSnapshotExt = timerfactory.Create<Finance.IMultiFSBLedgerCompressSnapshot>(_MultiFSBLedgerCompressSnapshot);
			
			return iMultiFSBLedgerCompressSnapshotExt;
		}
	}
}
