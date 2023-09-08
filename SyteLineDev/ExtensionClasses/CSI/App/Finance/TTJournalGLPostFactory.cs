//PROJECT NAME: Finance
//CLASS NAME: TTJournalGLPostFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class TTJournalGLPostFactory
	{
		public ITTJournalGLPost Create(IApplicationDB appDB)
		{
			var _TTJournalGLPost = new Finance.TTJournalGLPost(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTTJournalGLPostExt = timerfactory.Create<Finance.ITTJournalGLPost>(_TTJournalGLPost);
			
			return iTTJournalGLPostExt;
		}
	}
}
