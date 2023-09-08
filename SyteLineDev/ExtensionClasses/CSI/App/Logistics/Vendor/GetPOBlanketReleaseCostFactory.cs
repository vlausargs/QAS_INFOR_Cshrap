//PROJECT NAME: Logistics
//CLASS NAME: GetPOBlanketReleaseCostFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class GetPOBlanketReleaseCostFactory
	{
		public IGetPOBlanketReleaseCost Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetPOBlanketReleaseCost = new Logistics.Vendor.GetPOBlanketReleaseCost(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetPOBlanketReleaseCostExt = timerfactory.Create<Logistics.Vendor.IGetPOBlanketReleaseCost>(_GetPOBlanketReleaseCost);
			
			return iGetPOBlanketReleaseCostExt;
		}
	}
}
