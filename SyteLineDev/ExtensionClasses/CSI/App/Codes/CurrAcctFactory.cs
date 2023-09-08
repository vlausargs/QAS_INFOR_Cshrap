//PROJECT NAME: Codes
//CLASS NAME: CurrAcctFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Codes
{
	public class CurrAcctFactory
	{
		public ICurrAcct Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CurrAcct = new Codes.CurrAcct(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCurrAcctExt = timerfactory.Create<Codes.ICurrAcct>(_CurrAcct);
			
			return iCurrAcctExt;
		}
	}
}
