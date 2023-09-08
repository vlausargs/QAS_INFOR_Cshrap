//PROJECT NAME: Logistics
//CLASS NAME: THACheckWHFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class THACheckWHFactory
	{
		public ITHACheckWH Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _THACheckWH = new Logistics.Vendor.THACheckWH(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iTHACheckWHExt = timerfactory.Create<Logistics.Vendor.ITHACheckWH>(_THACheckWH);
			
			return iTHACheckWHExt;
		}
	}
}
