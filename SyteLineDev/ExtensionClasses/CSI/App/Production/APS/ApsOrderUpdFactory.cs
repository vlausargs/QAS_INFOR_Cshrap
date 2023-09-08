//PROJECT NAME: Production
//CLASS NAME: ApsOrderUpdFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class ApsOrderUpdFactory
	{
		public IApsOrderUpd Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ApsOrderUpd = new Production.APS.ApsOrderUpd(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsOrderUpdExt = timerfactory.Create<Production.APS.IApsOrderUpd>(_ApsOrderUpd);
			
			return iApsOrderUpdExt;
		}
	}
}
