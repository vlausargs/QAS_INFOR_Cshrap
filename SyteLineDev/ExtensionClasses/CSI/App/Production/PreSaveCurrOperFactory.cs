//PROJECT NAME: Production
//CLASS NAME: PreSaveCurrOperFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class PreSaveCurrOperFactory
	{
		public IPreSaveCurrOper Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PreSaveCurrOper = new Production.PreSaveCurrOper(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPreSaveCurrOperExt = timerfactory.Create<Production.IPreSaveCurrOper>(_PreSaveCurrOper);
			
			return iPreSaveCurrOperExt;
		}
	}
}
