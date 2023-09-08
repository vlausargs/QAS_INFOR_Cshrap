//PROJECT NAME: Codes
//CLASS NAME: JournalCalcExchRateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Codes
{
	public class JournalCalcExchRateFactory
	{
		public IJournalCalcExchRate Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _JournalCalcExchRate = new Codes.JournalCalcExchRate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJournalCalcExchRateExt = timerfactory.Create<Codes.IJournalCalcExchRate>(_JournalCalcExchRate);
			
			return iJournalCalcExchRateExt;
		}
	}
}
