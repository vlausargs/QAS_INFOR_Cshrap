//PROJECT NAME: Production
//CLASS NAME: RerankJobmatlFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class RerankJobmatlFactory
	{
		public IRerankJobmatl Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _RerankJobmatl = new Production.RerankJobmatl(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iRerankJobmatlExt = timerfactory.Create<Production.IRerankJobmatl>(_RerankJobmatl);
			
			return iRerankJobmatlExt;
		}
	}
}
