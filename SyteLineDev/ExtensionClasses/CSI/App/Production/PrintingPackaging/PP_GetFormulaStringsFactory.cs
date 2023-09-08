//PROJECT NAME: Production
//CLASS NAME: PP_GetFormulaStringsFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.PrintingPackaging
{
	public class PP_GetFormulaStringsFactory
	{
		public IPP_GetFormulaStrings Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _PP_GetFormulaStrings = new Production.PrintingPackaging.PP_GetFormulaStrings(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPP_GetFormulaStringsExt = timerfactory.Create<Production.PrintingPackaging.IPP_GetFormulaStrings>(_PP_GetFormulaStrings);
			
			return iPP_GetFormulaStringsExt;
		}
	}
}
