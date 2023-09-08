//PROJECT NAME: Production
//CLASS NAME: ApsWhseMatlInsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class ApsWhseMatlInsFactory
	{
		public IApsWhseMatlIns Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ApsWhseMatlIns = new Production.APS.ApsWhseMatlIns(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsWhseMatlInsExt = timerfactory.Create<Production.APS.IApsWhseMatlIns>(_ApsWhseMatlIns);
			
			return iApsWhseMatlInsExt;
		}
	}
}
