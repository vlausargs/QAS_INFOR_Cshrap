//PROJECT NAME: Finance
//CLASS NAME: LedgerCompressSnapshotFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class LedgerCompressSnapshotFactory
	{
		public ILedgerCompressSnapshot Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _LedgerCompressSnapshot = new Finance.LedgerCompressSnapshot(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLedgerCompressSnapshotExt = timerfactory.Create<Finance.ILedgerCompressSnapshot>(_LedgerCompressSnapshot);
			
			return iLedgerCompressSnapshotExt;
		}
	}
}
