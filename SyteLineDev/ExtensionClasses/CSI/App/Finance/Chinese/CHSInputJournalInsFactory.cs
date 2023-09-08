//PROJECT NAME: Finance
//CLASS NAME: CHSInputJournalInsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance.Chinese
{
	public class CHSInputJournalInsFactory
	{
		public ICHSInputJournalIns Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CHSInputJournalIns = new Finance.Chinese.CHSInputJournalIns(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCHSInputJournalInsExt = timerfactory.Create<Finance.Chinese.ICHSInputJournalIns>(_CHSInputJournalIns);
			
			return iCHSInputJournalInsExt;
		}
	}
}
