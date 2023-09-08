//PROJECT NAME: Production
//CLASS NAME: PP_GetPrintRootJobQtysFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production
{
	public class PP_GetPrintRootJobQtysFactory
	{
		public IPP_GetPrintRootJobQtys Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PP_GetPrintRootJobQtys = new Production.PP_GetPrintRootJobQtys(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPP_GetPrintRootJobQtysExt = timerfactory.Create<Production.IPP_GetPrintRootJobQtys>(_PP_GetPrintRootJobQtys);
			
			return iPP_GetPrintRootJobQtysExt;
		}
	}
}
