//PROJECT NAME: Production
//CLASS NAME: PP_SavePrintingJobRouteDataFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class PP_SavePrintingJobRouteDataFactory
	{
		public IPP_SavePrintingJobRouteData Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PP_SavePrintingJobRouteData = new Production.PP_SavePrintingJobRouteData(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPP_SavePrintingJobRouteDataExt = timerfactory.Create<Production.IPP_SavePrintingJobRouteData>(_PP_SavePrintingJobRouteData);
			
			return iPP_SavePrintingJobRouteDataExt;
		}
	}
}
