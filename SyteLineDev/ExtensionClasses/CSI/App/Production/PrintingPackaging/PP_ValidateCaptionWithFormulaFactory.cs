//PROJECT NAME: CSIPPIndPack
//CLASS NAME: PP_ValidateCaptionWithFormulaFactory.cs

using CSI.MG;

namespace CSI.Production.PrintingPackaging
{
	public class PP_ValidateCaptionWithFormulaFactory
	{
		public IPP_ValidateCaptionWithFormula Create(IApplicationDB appDB)
		{
			var _PP_ValidateCaptionWithFormula = new Production.PrintingPackaging.PP_ValidateCaptionWithFormula(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iPP_ValidateCaptionWithFormulaExt = timerfactory.Create<Production.PrintingPackaging.IPP_ValidateCaptionWithFormula>(_PP_ValidateCaptionWithFormula);
			
			return iPP_ValidateCaptionWithFormulaExt;
		}
	}
}
