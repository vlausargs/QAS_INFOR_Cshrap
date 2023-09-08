//PROJECT NAME: Finance
//CLASS NAME: JournalGetCashAccountBankCodeFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class JournalGetCashAccountBankCodeFactory
	{
		public IJournalGetCashAccountBankCode Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _JournalGetCashAccountBankCode = new Finance.JournalGetCashAccountBankCode(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iJournalGetCashAccountBankCodeExt = timerfactory.Create<Finance.IJournalGetCashAccountBankCode>(_JournalGetCashAccountBankCode);
			
			return iJournalGetCashAccountBankCodeExt;
		}
	}
}
