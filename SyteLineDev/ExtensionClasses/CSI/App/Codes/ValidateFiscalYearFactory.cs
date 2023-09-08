//PROJECT NAME: Codes
//CLASS NAME: ValidateFiscalYearFactory.cs

using CSI.MG;
using CSI.Data.SQL;

namespace CSI.Codes
{
	public class ValidateFiscalYearFactory
	{
		public IValidateFiscalYear Create(IApplicationDB appDB,
		IMGInvoker mgInvoker,
		IParameterProvider parameterProvider,
		bool calledFromIDO)
		{
			var _ValidateFiscalYear = new Codes.ValidateFiscalYear(appDB);
			
			var timerfactory = new CSI.Data.Metric.TimerFactory();
			var iValidateFiscalYearExt = timerfactory.Create<Codes.IValidateFiscalYear>(_ValidateFiscalYear);
			
			return iValidateFiscalYearExt;
		}
	}
}
