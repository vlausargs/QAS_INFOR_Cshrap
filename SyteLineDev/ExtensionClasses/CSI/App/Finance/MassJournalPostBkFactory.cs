//PROJECT NAME: Finance
//CLASS NAME: MassJournalPostBkFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class MassJournalPostBkFactory
	{
		public IMassJournalPostBk Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _MassJournalPostBk = new Finance.MassJournalPostBk(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMassJournalPostBkExt = timerfactory.Create<Finance.IMassJournalPostBk>(_MassJournalPostBk);
			
			return iMassJournalPostBkExt;
		}
	}
}
