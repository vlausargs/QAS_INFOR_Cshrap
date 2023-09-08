//PROJECT NAME: Finance
//CLASS NAME: BankBalFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance
{
	public class BankBalFactory
	{
		public IBankBal Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _BankBal = new Finance.BankBal(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iBankBalExt = timerfactory.Create<Finance.IBankBal>(_BankBal);
			
			return iBankBalExt;
		}
	}
}
