//PROJECT NAME: Production
//CLASS NAME: PreSaveCostAltCurrOperFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class PreSaveCostAltCurrOperFactory
	{
		public IPreSaveCostAltCurrOper Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PreSaveCostAltCurrOper = new Production.PreSaveCostAltCurrOper(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPreSaveCostAltCurrOperExt = timerfactory.Create<Production.IPreSaveCostAltCurrOper>(_PreSaveCostAltCurrOper);
			
			return iPreSaveCostAltCurrOperExt;
		}
	}
}
