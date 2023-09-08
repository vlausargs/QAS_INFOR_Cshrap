//PROJECT NAME: Material
//CLASS NAME: MRPFirmPlanOrdersFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Material
{
	public class MRPFirmPlanOrdersFactory
	{
		public IMRPFirmPlanOrders Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _MRPFirmPlanOrders = new Material.MRPFirmPlanOrders(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iMRPFirmPlanOrdersExt = timerfactory.Create<Material.IMRPFirmPlanOrders>(_MRPFirmPlanOrders);
			
			return iMRPFirmPlanOrdersExt;
		}
	}
}
