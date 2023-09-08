//PROJECT NAME: Finance
//CLASS NAME: SSSCCIPayInvoicesFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance.CreditCard
{
	public class SSSCCIPayInvoicesFactory
	{
		public ISSSCCIPayInvoices Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SSSCCIPayInvoices = new Finance.CreditCard.SSSCCIPayInvoices(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSCCIPayInvoicesExt = timerfactory.Create<Finance.CreditCard.ISSSCCIPayInvoices>(_SSSCCIPayInvoices);
			
			return iSSSCCIPayInvoicesExt;
		}
	}
}
