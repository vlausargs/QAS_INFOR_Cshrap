//PROJECT NAME: Finance
//CLASS NAME: TTJournalPostFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class TTJournalPostFactory
	{
		public ITTJournalPost Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _TTJournalPost = new Finance.TTJournalPost(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTTJournalPostExt = timerfactory.Create<Finance.ITTJournalPost>(_TTJournalPost);
			
			return iTTJournalPostExt;
		}
	}
}
