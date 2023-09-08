//PROJECT NAME: Production
//CLASS NAME: ApsWhseDelFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class ApsWhseDelFactory
	{
		public IApsWhseDel Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ApsWhseDel = new Production.APS.ApsWhseDel(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsWhseDelExt = timerfactory.Create<Production.APS.IApsWhseDel>(_ApsWhseDel);
			
			return iApsWhseDelExt;
		}
	}
}
