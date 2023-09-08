//PROJECT NAME: Production
//CLASS NAME: ApsMatlInsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class ApsMatlInsFactory
	{
		public IApsMatlIns Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ApsMatlIns = new Production.APS.ApsMatlIns(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsMatlInsExt = timerfactory.Create<Production.APS.IApsMatlIns>(_ApsMatlIns);
			
			return iApsMatlInsExt;
		}
	}
}
