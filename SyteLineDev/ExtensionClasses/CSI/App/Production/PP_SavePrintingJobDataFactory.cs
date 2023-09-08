//PROJECT NAME: Production
//CLASS NAME: PP_SavePrintingJobDataFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class PP_SavePrintingJobDataFactory
	{
		public IPP_SavePrintingJobData Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PP_SavePrintingJobData = new Production.PP_SavePrintingJobData(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPP_SavePrintingJobDataExt = timerfactory.Create<Production.IPP_SavePrintingJobData>(_PP_SavePrintingJobData);
			
			return iPP_SavePrintingJobDataExt;
		}
	}
}
