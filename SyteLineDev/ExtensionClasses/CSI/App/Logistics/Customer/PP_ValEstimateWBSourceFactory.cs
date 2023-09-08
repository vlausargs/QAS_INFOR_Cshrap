//PROJECT NAME: Logistics
//CLASS NAME: PP_ValEstimateWBSourceFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Logistics.Customer
{
	public class PP_ValEstimateWBSourceFactory
	{
		public IPP_ValEstimateWBSource Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PP_ValEstimateWBSource = new Logistics.Customer.PP_ValEstimateWBSource(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPP_ValEstimateWBSourceExt = timerfactory.Create<Logistics.Customer.IPP_ValEstimateWBSource>(_PP_ValEstimateWBSource);
			
			return iPP_ValEstimateWBSourceExt;
		}
	}
}
