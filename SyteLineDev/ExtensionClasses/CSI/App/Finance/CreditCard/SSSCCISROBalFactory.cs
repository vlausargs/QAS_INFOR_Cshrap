//PROJECT NAME: Finance
//CLASS NAME: SSSCCISROBalFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Finance.CreditCard
{
	public class SSSCCISROBalFactory
	{
		public ISSSCCISROBal Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SSSCCISROBal = new Finance.CreditCard.SSSCCISROBal(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSSSCCISROBalExt = timerfactory.Create<Finance.CreditCard.ISSSCCISROBal>(_SSSCCISROBal);
			
			return iSSSCCISROBalExt;
		}
	}
}
