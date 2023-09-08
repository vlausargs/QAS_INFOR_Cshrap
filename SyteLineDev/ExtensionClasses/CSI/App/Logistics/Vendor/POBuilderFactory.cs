//PROJECT NAME: Logistics
//CLASS NAME: POBuilderFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class POBuilderFactory
	{
		public IPOBuilder Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _POBuilder = new Logistics.Vendor.POBuilder(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPOBuilderExt = timerfactory.Create<Logistics.Vendor.IPOBuilder>(_POBuilder);
			
			return iPOBuilderExt;
		}
	}
}
