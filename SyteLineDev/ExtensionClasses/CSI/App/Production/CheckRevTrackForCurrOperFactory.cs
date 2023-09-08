//PROJECT NAME: Production
//CLASS NAME: CheckRevTrackForCurrOperFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class CheckRevTrackForCurrOperFactory
	{
		public ICheckRevTrackForCurrOper Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CheckRevTrackForCurrOper = new Production.CheckRevTrackForCurrOper(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCheckRevTrackForCurrOperExt = timerfactory.Create<Production.ICheckRevTrackForCurrOper>(_CheckRevTrackForCurrOper);
			
			return iCheckRevTrackForCurrOperExt;
		}
	}
}
