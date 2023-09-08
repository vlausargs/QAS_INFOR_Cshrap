//PROJECT NAME: Production
//CLASS NAME: FormulaTermValidateFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Production.PrintingPackaging
{
	public class FormulaTermValidateFactory
	{
		public IFormulaTermValidate Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _FormulaTermValidate = new Production.PrintingPackaging.FormulaTermValidate(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iFormulaTermValidateExt = timerfactory.Create<Production.PrintingPackaging.IFormulaTermValidate>(_FormulaTermValidate);
			
			return iFormulaTermValidateExt;
		}
	}
}
