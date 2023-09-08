//PROJECT NAME: Production
//CLASS NAME: PP_SumPrintQuotePriceForRootJobFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class PP_SumPrintQuotePriceForRootJobFactory
	{
		public IPP_SumPrintQuotePriceForRootJob Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PP_SumPrintQuotePriceForRootJob = new Production.PP_SumPrintQuotePriceForRootJob(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPP_SumPrintQuotePriceForRootJobExt = timerfactory.Create<Production.IPP_SumPrintQuotePriceForRootJob>(_PP_SumPrintQuotePriceForRootJob);
			
			return iPP_SumPrintQuotePriceForRootJobExt;
		}
	}
}
