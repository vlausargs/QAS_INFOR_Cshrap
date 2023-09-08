//PROJECT NAME: Production
//CLASS NAME: ApsWhseInsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class ApsWhseInsFactory
	{
		public IApsWhseIns Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ApsWhseIns = new Production.APS.ApsWhseIns(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsWhseInsExt = timerfactory.Create<Production.APS.IApsWhseIns>(_ApsWhseIns);
			
			return iApsWhseInsExt;
		}
	}
}
