//PROJECT NAME: Logistics
//CLASS NAME: GetChartInfoFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Vendor
{
	public class GetChartInfoFactory
	{
		public IGetChartInfo Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _GetChartInfo = new Logistics.Vendor.GetChartInfo(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iGetChartInfoExt = timerfactory.Create<Logistics.Vendor.IGetChartInfo>(_GetChartInfo);
			
			return iGetChartInfoExt;
		}
	}
}
