//PROJECT NAME: Finance
//CLASS NAME: JournalValidBankCodeFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class JournalValidBankCodeFactory
	{
		public IJournalValidBankCode Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _JournalValidBankCode = new Finance.JournalValidBankCode(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJournalValidBankCodeExt = timerfactory.Create<Finance.IJournalValidBankCode>(_JournalValidBankCode);
			
			return iJournalValidBankCodeExt;
		}
	}
}
