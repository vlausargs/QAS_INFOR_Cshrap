//PROJECT NAME: Production
//CLASS NAME: PP_PostSavePrintingEstWorkbenchOperFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class PP_PostSavePrintingEstWorkbenchOperFactory
	{
		public IPP_PostSavePrintingEstWorkbenchOper Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PP_PostSavePrintingEstWorkbenchOper = new Production.PP_PostSavePrintingEstWorkbenchOper(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPP_PostSavePrintingEstWorkbenchOperExt = timerfactory.Create<Production.IPP_PostSavePrintingEstWorkbenchOper>(_PP_PostSavePrintingEstWorkbenchOper);
			
			return iPP_PostSavePrintingEstWorkbenchOperExt;
		}
	}
}
