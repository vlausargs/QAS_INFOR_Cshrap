//PROJECT NAME: Production
//CLASS NAME: SetItemValuesForCurrOperFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class SetItemValuesForCurrOperFactory
	{
		public ISetItemValuesForCurrOper Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _SetItemValuesForCurrOper = new Production.SetItemValuesForCurrOper(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iSetItemValuesForCurrOperExt = timerfactory.Create<Production.ISetItemValuesForCurrOper>(_SetItemValuesForCurrOper);
			
			return iSetItemValuesForCurrOperExt;
		}
	}
}
