//PROJECT NAME: Production
//CLASS NAME: GetEcnValueForCurrOperFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class GetEcnValueForCurrOperFactory
	{
		public IGetEcnValueForCurrOper Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetEcnValueForCurrOper = new Production.GetEcnValueForCurrOper(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetEcnValueForCurrOperExt = timerfactory.Create<Production.IGetEcnValueForCurrOper>(_GetEcnValueForCurrOper);
			
			return iGetEcnValueForCurrOperExt;
		}
	}
}
