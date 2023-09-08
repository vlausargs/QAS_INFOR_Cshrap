//PROJECT NAME: Production
//CLASS NAME: ApsCtpXRefFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class ApsCtpXRefFactory
	{
		public IApsCtpXRef Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ApsCtpXRef = new Production.APS.ApsCtpXRef(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsCtpXRefExt = timerfactory.Create<Production.APS.IApsCtpXRef>(_ApsCtpXRef);
			
			return iApsCtpXRefExt;
		}
	}
}
