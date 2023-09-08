//PROJECT NAME: Production
//CLASS NAME: ApsOrderInsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class ApsOrderInsFactory
	{
		public IApsOrderIns Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ApsOrderIns = new Production.APS.ApsOrderIns(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsOrderInsExt = timerfactory.Create<Production.APS.IApsOrderIns>(_ApsOrderIns);
			
			return iApsOrderInsExt;
		}
	}
}
