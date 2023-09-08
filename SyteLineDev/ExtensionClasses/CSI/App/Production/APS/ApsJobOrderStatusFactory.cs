//PROJECT NAME: Production
//CLASS NAME: ApsJobOrderStatusFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.APS
{
	public class ApsJobOrderStatusFactory
	{
		public IApsJobOrderStatus Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ApsJobOrderStatus = new Production.APS.ApsJobOrderStatus(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iApsJobOrderStatusExt = timerfactory.Create<Production.APS.IApsJobOrderStatus>(_ApsJobOrderStatus);
			
			return iApsJobOrderStatusExt;
		}
	}
}
