//PROJECT NAME: Production
//CLASS NAME: LocalDisplayForCurrOperFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class LocalDisplayForCurrOperFactory
	{
		public ILocalDisplayForCurrOper Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _LocalDisplayForCurrOper = new Production.LocalDisplayForCurrOper(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iLocalDisplayForCurrOperExt = timerfactory.Create<Production.ILocalDisplayForCurrOper>(_LocalDisplayForCurrOper);
			
			return iLocalDisplayForCurrOperExt;
		}
	}
}
