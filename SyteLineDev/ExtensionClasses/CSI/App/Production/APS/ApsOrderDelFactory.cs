//PROJECT NAME: Production
//CLASS NAME: ApsOrderDelFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class ApsOrderDelFactory
	{
		public IApsOrderDel Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ApsOrderDel = new Production.APS.ApsOrderDel(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsOrderDelExt = timerfactory.Create<Production.APS.IApsOrderDel>(_ApsOrderDel);
			
			return iApsOrderDelExt;
		}
	}
}
