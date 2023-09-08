//PROJECT NAME: Finance
//CLASS NAME: GetLedgerBatchCounterFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class GetLedgerBatchCounterFactory
	{
		public IGetLedgerBatchCounter Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetLedgerBatchCounter = new Finance.GetLedgerBatchCounter(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetLedgerBatchCounterExt = timerfactory.Create<Finance.IGetLedgerBatchCounter>(_GetLedgerBatchCounter);
			
			return iGetLedgerBatchCounterExt;
		}
	}
}
