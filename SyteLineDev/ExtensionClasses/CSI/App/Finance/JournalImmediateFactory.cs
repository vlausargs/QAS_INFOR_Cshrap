//PROJECT NAME: Production
//CLASS NAME: JournalImmediateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class JournalImmediateFactory
	{
		public IJournalImmediate Create(ICSIExtensionClassBase cSIExtensionClassBase, bool calledFromIDO)
		{
			var appDB = cSIExtensionClassBase.AppDB;

			var _JournalImmediate = new Finance.JournalImmediate(appDB);

			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJournalImmediateExt = timerfactory.Create<Finance.IJournalImmediate>(_JournalImmediate);

			return iJournalImmediateExt;
		}
	}
}
