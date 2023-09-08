//PROJECT NAME: Production
//CLASS NAME: CheckOperNumForCurrOperFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class CheckOperNumForCurrOperFactory
	{
		public ICheckOperNumForCurrOper Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CheckOperNumForCurrOper = new Production.CheckOperNumForCurrOper(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCheckOperNumForCurrOperExt = timerfactory.Create<Production.ICheckOperNumForCurrOper>(_CheckOperNumForCurrOper);
			
			return iCheckOperNumForCurrOperExt;
		}
	}
}
