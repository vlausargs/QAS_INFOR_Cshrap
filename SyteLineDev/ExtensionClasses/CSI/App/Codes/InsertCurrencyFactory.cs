//PROJECT NAME: Codes
//CLASS NAME: InsertCurrencyFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Codes
{
	public class InsertCurrencyFactory
	{
		public IInsertCurrency Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _InsertCurrency = new Codes.InsertCurrency(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iInsertCurrencyExt = timerfactory.Create<Codes.IInsertCurrency>(_InsertCurrency);
			
			return iInsertCurrencyExt;
		}
	}
}
