//PROJECT NAME: Production
//CLASS NAME: PreDeleteCurrOperFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class PreDeleteCurrOperFactory
	{
		public IPreDeleteCurrOper Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PreDeleteCurrOper = new Production.PreDeleteCurrOper(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPreDeleteCurrOperExt = timerfactory.Create<Production.IPreDeleteCurrOper>(_PreDeleteCurrOper);
			
			return iPreDeleteCurrOperExt;
		}
	}
}
