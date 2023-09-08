//PROJECT NAME: Finance
//CLASS NAME: LedgerCompressPostCompleteFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class LedgerCompressPostCompleteFactory
	{
		public ILedgerCompressPostComplete Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _LedgerCompressPostComplete = new Finance.LedgerCompressPostComplete(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLedgerCompressPostCompleteExt = timerfactory.Create<Finance.ILedgerCompressPostComplete>(_LedgerCompressPostComplete);
			
			return iLedgerCompressPostCompleteExt;
		}
	}
}
