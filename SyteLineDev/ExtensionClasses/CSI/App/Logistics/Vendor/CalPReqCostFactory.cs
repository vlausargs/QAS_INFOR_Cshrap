//PROJECT NAME: Logistics
//CLASS NAME: CalPReqCostFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class CalPReqCostFactory
	{
		public ICalPReqCost Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _CalPReqCost = new Logistics.Vendor.CalPReqCost(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iCalPReqCostExt = timerfactory.Create<Logistics.Vendor.ICalPReqCost>(_CalPReqCost);
			
			return iCalPReqCostExt;
		}
	}
}
