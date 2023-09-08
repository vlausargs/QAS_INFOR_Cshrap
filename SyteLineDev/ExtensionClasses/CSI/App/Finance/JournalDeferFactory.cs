//PROJECT NAME: Production
//CLASS NAME: JournalDeferFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class JournalDeferFactory
	{
		public IJournalDefer Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;

			var _JournalDefer = new Finance.JournalDefer(appDB);

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJournalDeferExt = timerfactory.Create<Finance.IJournalDefer>(_JournalDefer);

			return iJournalDeferExt;
		}
	}
}
