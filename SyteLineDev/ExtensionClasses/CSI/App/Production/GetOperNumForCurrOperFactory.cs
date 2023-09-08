//PROJECT NAME: Production
//CLASS NAME: GetOperNumForCurrOperFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class GetOperNumForCurrOperFactory
	{
		public IGetOperNumForCurrOper Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetOperNumForCurrOper = new Production.GetOperNumForCurrOper(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetOperNumForCurrOperExt = timerfactory.Create<Production.IGetOperNumForCurrOper>(_GetOperNumForCurrOper);
			
			return iGetOperNumForCurrOperExt;
		}
	}
}
