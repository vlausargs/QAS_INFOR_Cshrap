//PROJECT NAME: CSIFinance
//CLASS NAME: IsRecurringJourPostFactory.cs

using CSI.MG;

namespace CSI.Finance
{
	public class IsRecurringJourPostFactory
	{
		public IIsRecurringJourPost Create(IApplicationDB appDB)
		{
			var _IsRecurringJourPost = new Finance.IsRecurringJourPost(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iIsRecurringJourPostExt = timerfactory.Create<Finance.IIsRecurringJourPost>(_IsRecurringJourPost);
			
			return iIsRecurringJourPostExt;
		}
	}
}
